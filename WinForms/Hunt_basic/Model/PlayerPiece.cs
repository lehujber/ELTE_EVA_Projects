using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunt_basic.Model
{
    internal class playerPosition
    {
        private int _xPos;
        private int _yPos;

        public int xPos => this._xPos;
        public int yPos => this._yPos;

        public (int, int) asTuple { get { return (this._xPos, this._yPos); } }

        public playerPosition(int x, int y)
        {
            this._xPos = x;
            this._yPos = y;
        }

        public void MoveY(int m)
        {
            this._yPos += m;
        }
        public void moveX(int m)
        {
            this._xPos += m;
        }

        public static bool operator ==(playerPosition p1, playerPosition p2) { return p1.asTuple == p2.asTuple; }
        public static bool operator !=(playerPosition p1, playerPosition p2) { return !(p1 == p2); }

        public override string ToString()
        {
            return $"{this.xPos},{this.yPos}";
        }
    }
    internal class PlayerPiece
    {
        private playerPosition _pos;
        public playerPosition position { get { return new playerPosition(this._pos.xPos,this._pos.yPos); } private set { this._pos = value; } }
        public PlayerPiece(int x, int y)
        {
            this._pos = new playerPosition(x, y);
        }

        public Dictionary<directions,playerPosition> neighbours
        {
            get
            {
                Dictionary<directions,playerPosition> neighs = new Dictionary<directions,playerPosition>();


                (int x, int y) pos = this.position.asTuple;
                neighs.Add(directions.LEFT,new playerPosition(pos.x - 1, pos.y));
                neighs.Add(directions.RIGHT,new playerPosition(pos.x + 1, pos.y));
                neighs.Add(directions.UP,new playerPosition(pos.x, pos.y-1));
                neighs.Add(directions.DOWN, new playerPosition(pos.x, pos.y+1));

                return neighs;
            }
        }

        public void Move(directions moveDirection)
        {
            switch (moveDirection)
            {
                case directions.UP:
                    this._pos.MoveY(-1);
                    break;
                case directions.DOWN:
                    this._pos.MoveY(1);
                    break;
                case directions.RIGHT:
                    this._pos.moveX(1);
                    break;
                case directions.LEFT:
                    this._pos.moveX(-1);
                    break;
                default:
                    break;
            }
        }

    }
}
