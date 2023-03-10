using Hunt_basic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunt_basic.Persistence
{
    internal interface IFileManager
    {
        public GameData Load();
        public void Save(GameData g);
    }

    public class FileManagerException : Exception { public FileManagerException(string msg) : base(msg) { } }


    internal class GameData
    {
        public readonly int gameSize;
        public readonly int remainingTurns;
        public readonly players nextStep;
        public readonly PlayerPiece[] huterPieces;
        public readonly PlayerPiece preyPiece;
        public GameData(int size, int turn, string nxtStep, string[] hunterPoss, string preyPos)
        {
            this.gameSize = size;
            this.remainingTurns = turn;

            if (nxtStep == "PREY")
            {
                this.nextStep = players.PREY;
            }
            else if (nxtStep == "HUNTER")
            {
                this.nextStep = players.HUNTER;
            }
            else
            {
                throw new FileManagerException("Faulty player type");
            }


            huterPieces = new PlayerPiece[4];
            for (int i = 0; i < hunterPoss.Length; i++)
            {
                var hPos = hunterPoss[i].Split(',');
                this.huterPieces[i] = new PlayerPiece(int.Parse(hPos[0]), int.Parse(hPos[1]));
            }

            var pPos = preyPos.Split(',');
            this.preyPiece = new PlayerPiece(int.Parse(pPos[0]), int.Parse(pPos[1]));
        }
        public GameData(int size, int remRound, players currStep, PlayerPiece[] hunters, PlayerPiece prey)
        {
            this.gameSize = size;
            this.remainingTurns = remRound;
            this.nextStep = currStep;
            this.huterPieces = hunters;
            this.preyPiece = prey;
        }
    }
}
