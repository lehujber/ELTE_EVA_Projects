using Hunt_basic.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hunt_basic.Model
{
    public class Game
    {
        private int _remRounds;

        public readonly int size;

        private readonly PlayerPiece[] hunterPieces = new PlayerPiece[4];
        private readonly PlayerPiece preyPiece;

        private players? _winner;
        private players _currStep;


        public players? winner { get { return this._winner; } private set { _winner = value; } }
        public int remRounds { get { return this._remRounds; } private set { this._remRounds = value; } }
        public (int, int)[] hunterPosions => hunterPieces.Select(x => x.position.asTuple).ToArray();
        public (int, int) preyPosition => this.preyPiece.position.asTuple;
        public players currentStep => this._currStep;
        internal GameData data { get { return new GameData(this.size, this.remRounds, this.currentStep, this.hunterPieces, this.preyPiece); } }

        public Game(int size)
        {
            this.size = size;
            this._remRounds = size * 4;

            hunterPieces[0] = new PlayerPiece(0, 0);
            hunterPieces[1] = new PlayerPiece(0, size - 1);
            hunterPieces[2] = new PlayerPiece(size - 1, 0);
            hunterPieces[3] = new PlayerPiece(size - 1, size - 1);

            this.preyPiece = new PlayerPiece(size / 2, size / 2);

            _currStep = players.PREY;
        }
        public Game(string path)
        {
            IFileManager manager = FileManagerFactory.CreateForPath(path);

            if (manager == null)
            {
                throw new IOException("Unsupported file type");
            }
            GameData gd = manager.Load();

            this.size = gd.gameSize;
            this._remRounds = gd.remainingTurns;

            for (int i = 0; i < hunterPieces.Length; i++)
            {
                hunterPieces[i] = gd.huterPieces[i];
            }

            this.preyPiece = gd.preyPiece;
            this._currStep = gd.nextStep;
        }

        public void save(string path)
        {
            IFileManager? manager = FileManagerFactory.CreateForPath(path);
            if (manager == null)
            {
                throw new IOException("Unsupported file type");
            }
            manager.Save(this.data);
        }
        private void nextRound()
        {
            this.remRounds -= 1;
            if (getPossiblePreyMoves().Length == 0)
            {
                this.winner = players.HUNTER;
            }
            else if (remRounds == 0)
            {
                this.winner = players.PREY;
            }

        }
        public void movePrey(directions dir)
        {
            if (this._currStep != players.PREY)
            {
                throw new WrongPlayerTurnException(players.PREY);
            }

            this.movePiece(this.preyPiece, dir);

            this._currStep = players.HUNTER;
        }
        public void moveHunter(directions dir, int ind)
        {
            if (this._currStep != players.HUNTER)
            {
                throw new WrongPlayerTurnException(players.HUNTER);
            }
            movePiece(hunterPieces[ind], dir);

            this._currStep = players.PREY;
            nextRound();
        }
        private void movePiece(PlayerPiece piece, directions dir)
        {

            if (winner != null)
            {
                throw new GameOverMoveException((players)winner);
            }

            List<playerPosition> occupied = this.hunterPieces.Append(preyPiece).Select(x => x.position).ToList();

            playerPosition[] possiblemoves = piece.neighbours.Values.Where(x => !occupied.Any(y => y == x) &&
                x.xPos < size && -1 < x.xPos &&
                x.yPos < size && -1 < x.yPos).ToArray();

            if (!possiblemoves.Any(x => x == piece.neighbours[dir]))
            {
                throw new CollisionErrorException(dir);
            }


            piece.Move(dir);
        }
        public directions[] getPossiblePreyMoves()
        {
            return getPossibleMoveDirections(preyPiece);
        }
        public directions[] getPossibleHunterDirections(int ind)
        {
            return getPossibleMoveDirections(hunterPieces[ind]);
        }
        private directions[] getPossibleMoveDirections(PlayerPiece piece)
        {
            List<playerPosition> occupied = this.hunterPieces.Append(preyPiece).Select(x => x.position).ToList();

            var neighs = piece.neighbours;

            return neighs.Where(x => !occupied.Any(y => y == x.Value) &&
                    x.Value.xPos < size && -1 < x.Value.xPos &&
                    x.Value.yPos < size && -1 < x.Value.yPos)
                    .Select(x => x.Key).ToArray();

        }

    }

    #region errors

    public abstract class HuntGameException : Exception
    {
        public HuntGameException(string msg) : base(msg) { }
    }

    public class WrongPlayerTurnException : HuntGameException
    {
        public WrongPlayerTurnException(players player) : base($"{(player == players.PREY ? "Prey" : "Hunter")} can not move now, as it is not their turn!") { }
    }
    public class CollisionErrorException : HuntGameException
    {
        public CollisionErrorException(directions dir) : base($"Selected figure can not move {dir}, as it is occupied, or out of bounds!") { }
    }
    public class GameOverMoveException : HuntGameException
    {
        public GameOverMoveException(players winner):base($"The game has already been won by {(winner == players.PREY ? "Prey" : "Hunter")}, " +
                        $"so no players can move now."){ }
    }

    #endregion

    #region enums
    public enum directions
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,
    }

    public enum players
    {
        HUNTER,
        PREY
    }
    #endregion
}
