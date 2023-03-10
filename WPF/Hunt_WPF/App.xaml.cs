using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Hunt_basic.Model;
using Hunt_WPF.ViewModel;
using Microsoft.Win32;

namespace Hunt_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Game _game = null!;
        private HuntViewModel _viewModel = null!;
        private MainWindow _view = null!;
        public App()
        {
            //MessageBox.Show(Path.GetFullPath("images/hunter.png"));
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object? sender, StartupEventArgs e)
        {
            CreateGame(3);
        }
        private void CreateGame(int size)
        {
            this._game = new Game(size);
            SetHandlers();
        }
        private void CreateGame(Game g)
        {
            this._game = g;
            SetHandlers();
        }

        private void SetHandlers()
        {
            this._viewModel = new HuntViewModel(this._game);
            _viewModel.ExitGame += new EventHandler(ViewModel_ExitGame);
            _viewModel.NewGame_Small += new EventHandler((sender, e) => ViewModel_NewGame(sender, e, 3));
            _viewModel.NewGame_Medium += new EventHandler((sender, e) => ViewModel_NewGame(sender, e, 5));
            _viewModel.NewGame_Large += new EventHandler((sender, e) => ViewModel_NewGame(sender, e, 7));
            _viewModel.SaveGame += new EventHandler(ViewModel_SaveGame);
            _viewModel.LoadGame += new EventHandler(ViewModel_LoadGame);
            _viewModel.GameOver+= new EventHandler((sender,e)=>ViewModel_GameOver(sender,e,_viewModel.Winner));



            if (this._view == null)
            {
                this._view = new MainWindow();
                this._view.Show();
            }
            this._view.DataContext = this._viewModel;
        }

        private void ViewModel_ExitGame(object? sender, EventArgs e)
        {
            this._view.Close();
        }
        private void ViewModel_NewGame(object? sender, EventArgs e, int size)
        {
            CreateGame(size);
        }
        private void ViewModel_SaveGame(object? sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == true)
            {
                try
                {
                    this._game.save(sfd.FileName);

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void ViewModel_LoadGame(object? sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                try
                {
                    CreateGame(new Game(ofd.FileName));
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void ViewModel_GameOver(object? sender, EventArgs e, players? winner) {
            if (winner!=null)
            {
                string w = "hunter";
                if (winner == players.PREY)
                {
                    w = "prey";
                }
                MessageBox.Show($"The winner is {w}");

                CreateGame(this._viewModel.Size);
            }
        }
    }

}
