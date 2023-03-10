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

namespace Hunt_MAUI.ViewModel
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
        public DelegateCommand NewGameCommand { get; private set; }
        public DelegateCommand DeleteSavesCommand { get; private set; }
        public string RemRounds => $"Remaining rounds: {this._game.remRounds}";
        public string NextTurn => (_game.currentStep == players.PREY ? "Prey" : "Hunter") + "'s turn";
        public players? Winner => this._game.winner;

        public RowDefinitionCollection GameTableRows => new RowDefinitionCollection(Enumerable.Repeat(new RowDefinition(GridLength.Star), Size).ToArray());
        public ColumnDefinitionCollection GameTableColumns => new ColumnDefinitionCollection(Enumerable.Repeat(new ColumnDefinition(GridLength.Star), Size).ToArray());

        public HuntViewModel(Game g)
        {
            this._game = g;
            this.NewGameCommand_Small = new DelegateCommand(p => OnNewGame_small());
            this.NewGameCommand_Medium = new DelegateCommand(p => OnNewGame_medium());
            this.NewGameCommand_Large = new DelegateCommand(p => OnNewGame_large());
            this.LoadGameCommand = new DelegateCommand(p => OnLoadGame());
            this.SaveGameCommand = new DelegateCommand(p => OnSaveGame());
            this.ExitCommand = new DelegateCommand(p => OnExitGame());
            this.NewGameCommand = new DelegateCommand(p => OnNewGame(Convert.ToInt32(p)));
            this.DeleteSavesCommand = new DelegateCommand(p=>OnDeleteSaves());


            Fields = new ObservableCollection<BoardField>();

            for (int i = 0; i < g.size; i++)
            {
                for (int j = 0; j < g.size; j++)
                {
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
        public EventHandler<int>? NewGame;
        public EventHandler? LoadGame;
        public EventHandler? SaveGame;
        public EventHandler? ExitGame;
        public EventHandler? GameOver;
        public EventHandler? DeleteSaves;

        private void RefreshTable()
        {
            for (int i = 0; i < this.Fields.Count; i++)
            {
                var field = this.Fields[i];
                field.Color = i % 2;
                field.Figure = this._game.hunterPosions.Contains(field.AsTuple) ? players.HUNTER : (this._game.preyPosition == (field.AsTuple) ? players.PREY : null);

                field.Type = fieldTypes.DEFAULT;
                if (field.Figure == this._game.currentStep)
                {
                    field.Type = fieldTypes.MOVEABLE;
                }
            }

            OnPropertyChanged(nameof(this.RemRounds));
            OnPropertyChanged(nameof(this.NextTurn));
            if (this._game.winner != null)
            {
                GameOver?.Invoke(this, EventArgs.Empty);
            }
        }
        private void OnNewGame_small() => this.NewGame_Small?.Invoke(this, EventArgs.Empty);
        private void OnNewGame_medium() => this.NewGame_Medium?.Invoke(this, EventArgs.Empty);
        private void OnNewGame_large() => this.NewGame_Large?.Invoke(this, EventArgs.Empty);
        private void OnLoadGame() => this.LoadGame?.Invoke(this, EventArgs.Empty);
        private void OnSaveGame() => this.SaveGame?.Invoke(this, EventArgs.Empty);
        private void OnExitGame() => this.ExitGame?.Invoke(this, EventArgs.Empty);
        private void OnNewGame(int size) => this.NewGame?.Invoke(this, 3 + (size == -1 ? 0 : size * 2));
        private void OnDeleteSaves() => this.DeleteSaves?.Invoke(this,EventArgs.Empty);
        private BoardField[] GetNeighbours(BoardField f) => Fields.Where(x => (Math.Abs(x.X - f.X) == 1 && x.Y == f.Y) || (Math.Abs(x.Y - f.Y) == 1 && x.X == f.X))
            .Where(x=> x.Figure == null).ToArray();
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
                    directions? dir = _game.indexToMoveDirection(Fields.IndexOf(selected),ind);
                    if (dir == null)
                    {
                        return;
                    }

                    if (_game.currentStep == players.HUNTER)
                    {
                        int moveInd = _game.hunterPosions.ToList().IndexOf(selected.AsTuple);
                        _game.moveHunter(dir.Value, moveInd);
                    }
                    else
                    {
                        _game.movePrey(dir.Value);
                    }

                    RefreshTable();
                    break;
                case fieldTypes.MOVEABLE:
                    foreach (var field in Fields)
                    {
                        field.Type = fieldTypes.DEFAULT;
                    }
                    foreach (var neig in GetNeighbours(clicked))
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
