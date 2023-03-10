using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hunt_basic.Model;

namespace Hunt_WinForms
{
    public partial class GameField : UserControl
    {
        private readonly Game game;
        private Label[][] fields;

        private Label preyField;
        private (int x, int y) preyPosition;
        private EventHandler preyHandler;
        private Image preyImage = Image.FromFile("images/prey.png");

        private Label[] hunterFields;
        private (int x, int y)[] hunterPositions;
        private EventHandler[] hunterHandlers = new EventHandler[4];
        private Image hunterImage = Image.FromFile("images/hunter.png");

        private Image indicatorImage = Image.FromFile("images/indicator_s.png");

        private Dictionary <Label, EventHandler> neighbourEvents = new Dictionary<Label, EventHandler>();

        private int boardSize;


        SideMenu sm;

        public GameField(int size)
        {
            game = new Game(size);
            this.boardSize = game.size;

            initialSetup();
        }
        public GameField(string path)
        {
            try
            {
                game = new Game(path);
                this.boardSize = game.size;
            }
            catch (Exception e)
            {

               throw e;
            }
            initialSetup();
        }

        private void initialSetup() {

            InitializeComponent();

            sm = new SideMenu(game);
            this.Dock = DockStyle.Fill;
            this.AutoSize = false;

            this.pnl_board.ColumnCount = boardSize;
            this.pnl_board.RowCount = boardSize;

            this.pnl_board.RowStyles.Clear();
            this.pnl_board.ColumnStyles.Clear();
            for (int i = 0; i < boardSize; i++)
            {
                this.pnl_board.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (float)100 / boardSize));
                this.pnl_board.RowStyles.Add(new RowStyle(SizeType.Percent, (float)100 / boardSize));
            }

            getBoard();
            drawBoard();

            pnl_gameField.Controls.Add(sm, 1, 0);
        }
        private void getBoard()
        {
            pnl_board.Controls.Clear();
            fields = new Label[boardSize][];
            for (int i = 0; i < pnl_board.ColumnCount; i++)
            {
                Label[] row = new Label[boardSize];
                for (int j = 0; j < pnl_board.RowCount; j++)
                {

                    Label lbl = new Label();
                    lbl.ForeColor = Color.Black;

                    lbl.Dock = DockStyle.Fill;

                    row[j] = lbl;
                    pnl_board.Controls.Add(lbl, i, j);


                }
                fields[i] = row;
            }
        }
        private void drawBoard()
        {
            sm.updateGameData(game.remRounds, game.currentStep == players.PREY ? "Prey" : "Hunter");

            createBoardLogic();

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    fields[i][j].Image = null;
                    if ((i + j) % 2 == 0)
                    {
                        fields[i][j].BackColor = ColorTranslator.FromHtml("#51557E");
                    }
                    else
                    {
                        fields[i][j].BackColor = ColorTranslator.FromHtml("#D6D5A8");

                    }

                    preyField.Image = preyImage;
                    foreach (var field in hunterFields)
                    {
                        field.Image = hunterImage;
                    }

                }
            }

            hunterFields = new Label[4];
            hunterPositions = game.hunterPosions;
            for (int i = 0; i < hunterPositions.Length; i++)
            {
                hunterFields[i] = fields[hunterPositions[i].x][hunterPositions[i].y];
            }
        }
        private void createBoardLogic()
        {

            preyPosition = game.preyPosition;
            preyField = fields[preyPosition.x][preyPosition.y];

            hunterFields = new Label[4];
            hunterPositions = game.hunterPosions;
            for (int i = 0; i < hunterPositions.Length; i++)
            {
                hunterFields[i] = fields[hunterPositions[i].x][hunterPositions[i].y];
            }

            clearNeighbours();
            neighbourEvents = new Dictionary<Label, EventHandler>();


            clearHunters();
            hunterHandlers = new EventHandler[4];
            hunterHandlers[0] = (sender, e) => highlightPossibleMoves(0);
            hunterHandlers[1] = (sender, e) => highlightPossibleMoves(1);
            hunterHandlers[2] = (sender, e) => highlightPossibleMoves(2);
            hunterHandlers[3] = (sender, e) => highlightPossibleMoves(3);
            //for (int i = 0; i < hunterHandlers.Length; i++)
            //{
            //    hunterHandlers[i] = (sender, e) => highlightPossibleMoves(i);
            //}

            preyField.Click -= preyHandler;

            if (game.currentStep == players.PREY)
            {
                preyHandler = (sender, e) => highlightPossibleMoves(-1);
                preyField.Click += preyHandler;

            }
            else
            {
                setHunters();
            }

        }
        private void clearNeighbours()
        {
            foreach (var e in neighbourEvents)
            {
                e.Key.Click -= e.Value;
            }
            neighbourEvents.Clear();
        }
        private void setHunters()
        {
            for (int i = 0; i < hunterFields.Length; i++)
            {
                hunterFields[i].Click += hunterHandlers[i];
            }
        }
        private void clearHunters()
        {
            for (int i = 0; i < hunterFields.Length; i++)
            {
                hunterFields[i].Click -= hunterHandlers[i];
            }
        }
        private void highlightPossibleMoves(int ind)
        {
            clearNeighbours();
            (int x, int y) middle;
            directions[] possibleDirections;
            if (ind == -1)
            {
                preyField.Click-=preyHandler;
                preyHandler = (sender, e) => drawBoard();
                preyField.Click += preyHandler;

                possibleDirections = game.getPossiblePreyMoves();

                middle = preyPosition;
            }
            else
            {
                clearHunters();
                hunterHandlers[ind] = (sender, e) =>  drawBoard();
                hunterFields[ind].Click += hunterHandlers[ind];

                possibleDirections = game.getPossibleHunterDirections(ind);
                
                middle = hunterPositions[ind];
            }


            for (int i = 0; i < possibleDirections.Length; i++)
            {
                directions dir = possibleDirections[i];
                Label field;
                switch (dir)
                {
                    case directions.UP:
                        field = fields[middle.x][middle.y - 1];
                        break;
                    case directions.DOWN:
                        field = fields[middle.x][middle.y + 1];
                        break;
                    case directions.LEFT:
                        field = fields[middle.x - 1][middle.y];
                        break;
                    case directions.RIGHT:
                        field = fields[middle.x + 1][middle.y];
                        break;
                    default:
                        field = null;
                        break;
                }
                if (field != null)
                {
                    field.Image = indicatorImage;
                    neighbourEvents.Add(field, new EventHandler((sender, e) => movePiece(dir, ind)));
                    field.Click += neighbourEvents[field];

                }
            }


        }
        private void movePiece(directions dir, int ind)
        {
            if (ind == -1) { 
                game.movePrey(dir);
            }
            else { 
                game.moveHunter(dir, ind); 
            }

            preyField.Click -= preyHandler;
            clearNeighbours();
            clearHunters();
            drawBoard();

            if (game.winner!= null)
            {
                clearNeighbours();
                clearHunters();
                preyField.Click-=preyHandler;

                GameOver go = new GameOver(game.winner==players.PREY?"Prey":"Hunter");
                go.ShowDialog();
                var parent = this.Parent;

                GameField gf = new GameField(this.boardSize);
                this.Hide();
                parent.Controls.Add(gf);

                this.Dispose();
            }

        }
    }
}
