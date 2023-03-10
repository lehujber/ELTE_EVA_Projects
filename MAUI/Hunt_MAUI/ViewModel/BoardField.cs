using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hunt_basic.Model;

namespace Hunt_MAUI.ViewModel
{

    class BoardField : ViewModelBase
    {
        static string path = System.IO.Path.GetFullPath(".").ToString() + "/ViewModel/images/";

        private players? _figure;
        private int _color;
        private fieldTypes _type;


        public DelegateCommand InputCommand { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public fieldTypes Type
        {
            get => this._type;
            set
            {
                if (this._type != value)
                {
                    this._type = value;
                    OnPropertyChanged();
                    //if (this.Type == fieldTypes.DESTINATION)
                    //{
                    //    this.FigureImagePath = BoardField.path + "indicator_s.png";
                    //}
                    //else if (this.Figure == null)
                    //{
                    //    this.FigureImagePath = null;
                    //}

                    OnPropertyChanged(nameof(ContentImageType));

                }
            }
        }

        public (int, int) AsTuple => (this.X, this.Y);
        public players? Figure
        {
            get => this._figure;
            set
            {
                if (this._figure != value)
                {
                    this._figure = value;
                    OnPropertyChanged();
                    //this.FigureImagePath = this.Figure == players.PREY ? BoardField.path + "prey.png" : (this.Figure == players.HUNTER ? BoardField.path + "hunter.png" : null);
                    OnPropertyChanged(nameof(ContentImageType));
                }
            }
        }

        public BoardField(int x, int y, int col, players? p)
        {
            this.X = x;
            this.Y = y;
            this._color = col;
            this._figure = p;
            //this._isLocked = true;
            this.Type = fieldTypes.DEFAULT;
        }

        //public bool IsLocked
        //{
        //    get => this._isLocked;
        //    set
        //    {
        //        if (this._isLocked != value)
        //        {
        //            this._isLocked = value;
        //            OnPropertyChanged();
        //        }
        //    }
        //}

        public int Color
        {
            get => this._color;
            set
            {
                if (this._color != value)
                {
                    this._color = value;
                    OnPropertyChanged();
                }
            }
        }

        public string? ContentImageType
        {

            get
            {
                if (this._figure == players.HUNTER)
                {
                    return "hunter";
                }
                if (this._figure == players.PREY)
                {
                    return "prey";
                }
                if (this.Type == fieldTypes.DESTINATION)
                {
                    return "target";
                }
                return null;
            }
        }
    }
    public enum fieldTypes
    {
        SELECTED,
        DESTINATION,
        MOVEABLE,
        DEFAULT
    }
}
