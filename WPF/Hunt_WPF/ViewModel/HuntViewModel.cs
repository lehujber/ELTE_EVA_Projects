using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Hunt_basic.Model;

namespace Hunt_WPF.ViewModel
{
    class HuntViewModel : ViewModelBase
    {
        private Game _game;
        public ObservableCollection<BoardField> Fields { get; set; }
        public int Size => this._game.size;
        public DelegateCommand NewGameCommand_Small { get; private set; }
        public DelegateCommand NewGameCommand_Medium { get; private set; }
        public DelegateCommand NewGameCommand_Large { get; private set; }
        public DelegateCommand LoadGameCommand { get; private set; }
        public DelegateCommand SaveGameCommand { get; private set; }
        public DelegateCommand ExitCommand { get; private set; }
        public string RemRounds => $"Remaining rounds: {this._game.remRounds}";
        public string NextTurn => (_game.currentStep == players.PREY ? "Prey" : "Hunter") + "'s turn";
        public players? Winner => this._game.winner;

        public HuntViewModel(Game g)
        {
            this._game = g;
            this.NewGameCommand_Small = new DelegateCommand(p => OnNewGame_small());
            this.NewGameCommand_Medium = new DelegateCommand(p => OnNewGame_medium());
            this.NewGameCommand_Large = new DelegateCommand(p => OnNewGame_large());
            this.LoadGameCommand = new DelegateCommand(p => OnLoadGame());
            this.SaveGameCommand = new DelegateCommand(p => OnSaveGame());
            this.ExitCommand = new DelegateCommand(p => OnExitGame());


            Fields = new ObservableCollection<BoardField>();

            for (int i = 0; i < g.size; i++)
            {
                for (int j = 0; j < g.size; j++)
                {
                    //players? p = null;
                    //if ((i == 0 && j == 0) || (i == 0 && j == g.size - 1) || (i == g.size - 1 && j == 0) || (i == g.size - 1 && j == g.size - 1))
                    //{
                    //    p = players.HUNTER;
                    //}
                    //else if (i == g.size / 2 && j == g.size / 2)
                    //{
                    //    p = players.PREY;
                    //}

                    Fields.Add(new BoardField(j, i, (i + j) % 2, null));
                    int lastInd = Fields.Count - 1;
                    Fields[lastInd].InputCommand = new DelegateCommand(p => OnInput_Field(Convert.ToInt32(lastInd)));
                }


            }

            RefreshTable();

        }

        public EventHandler? NewGame_Small;
        public EventHandler? NewGame_Medium;
        public EventHandler? NewGame_Large;
        public EventHandler? LoadGame;
        public EventHandler? SaveGame;
        public EventHandler? ExitGame;
        public EventHandler? GameOver;

        private void RefreshTable()
        {
            for (int i = 0; i < this.Fields.Count; i++)
            {
                var field = this.Fields[i];
                field.Color = i % 2;
                field.Figure = this._game.hunterPosions.Contains(field.AsTuple) ? players.HUNTER : (this._game.preyPosition == (field.AsTuple) ? players.PREY : null);
                //field.IsLocked = field.Figure != this._game.currentStep;
                field.Type = fieldTypes.DEFAULT;
                if (field.Figure == this._game.currentStep)
                {
                    field.Type = fieldTypes.MOVEABLE;
                }
            }

            OnPropertyChanged(nameof(this.RemRounds));
            OnPropertyChanged(nameof(this.NextTurn));
            if (this._game.winner!=null)
            {
                GameOver?.Invoke(this,EventArgs.Empty);
            }
        }
        private void OnNewGame_small()
        {
            this.NewGame_Small?.Invoke(this, EventArgs.Empty);
        }
        private void OnNewGame_medium()
        {
            this.NewGame_Medium?.Invoke(this, EventArgs.Empty);
        }
        private void OnNewGame_large()
        {
            this.NewGame_Large?.Invoke(this, EventArgs.Empty);
        }
        private void OnLoadGame()
        {
            this.LoadGame?.Invoke(this, EventArgs.Empty);
        }
        private void OnSaveGame()
        {
            this.SaveGame?.Invoke(this, EventArgs.Empty);
        }
        private void OnExitGame()
        {
            this.ExitGame?.Invoke(this, EventArgs.Empty);
        }
        private void OnInput_Field(int ind)
        {
            BoardField clicked = Fields[ind];
            switch (clicked.Type)
            {
                case fieldTypes.SELECTED:
                    RefreshTable();
                    break;
                case fieldTypes.DESTINATION:
                    BoardField selected = Fields.First(x => x.Type == fieldTypes.SELECTED);
                    (int, int) destCords = clicked.AsTuple;
                    int direction = Fields.IndexOf(selected) - ind;
                    directions dir;
                    if (direction == 1)
                    {
                        dir = directions.LEFT;
                    }
                    else if (direction == -1)
                    {
                        dir = directions.RIGHT;
                    }
                    else if (0 < direction)
                    {
                        dir = directions.UP;
                    }
                    else
                    {
                        dir = directions.DOWN;
                    }

                    if (_game.currentStep == players.HUNTER)
                    {
                        int moveInd = _game.hunterPosions.ToList().IndexOf(selected.AsTuple);
                        _game.moveHunter(dir, moveInd);
                    }
                    else
                    {
                        _game.movePrey(dir);
                    }
                    RefreshTable();
                    break;
                case fieldTypes.MOVEABLE:
                    foreach (var field in Fields)
                    {
                        field.Type = fieldTypes.DEFAULT;
                    }
                    BoardField[] neighs = (new int[] { ind - _game.size, ind - 1, ind + 1, ind + _game.size }).Where(x => 0 <= x && x < _game.size * _game.size)
                        .Select(x => Fields[x]).Where(x => (x.X == clicked.X || x.Y == clicked.Y) && x.Figure == null).ToArray();
                    foreach (var neig in neighs)
                    {
                        neig.Type = fieldTypes.DESTINATION;
                    }
                    clicked.Type = fieldTypes.SELECTED;
                    break;
                case fieldTypes.DEFAULT:
                    break;
                default:
                    break;
            }

            this.OnPropertyChanged(nameof(Fields));
        }


        

       
    }
}
