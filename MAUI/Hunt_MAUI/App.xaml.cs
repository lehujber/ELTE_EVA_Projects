using Hunt_basic.Model;
using Hunt_MAUI.ViewModel;

namespace Hunt_MAUI;

public partial class App : Application
{
    private AppShell _appShell;
    private Game _game;
    private HuntViewModel _viewModel;

    public App()
    {
        CreateGame(3);

        InitializeComponent();
    }

    private void CreateGame(int s)
    {
        _game = new Game(s);
        _viewModel = new HuntViewModel(_game);

        _appShell = new AppShell();
        _appShell.BindingContext = _viewModel;

        _viewModel.ExitGame += new EventHandler(ExitGame);
        _viewModel.NewGame += new EventHandler<int>(NewGame);
        _viewModel.GameOver += new EventHandler(GameOver);
        _viewModel.LoadGame += new EventHandler(LoadGame);
        _viewModel.SaveGame += new EventHandler(SaveGame);
        _viewModel.DeleteSaves += new EventHandler(DeleteSaves);

        MainPage = _appShell;
    }
    private void CreateGame(string p)
    {
        _game = new Game(p);
        _viewModel = new HuntViewModel(_game);

        _appShell = new AppShell();
        _appShell.BindingContext = _viewModel;

        _viewModel.ExitGame += new EventHandler(ExitGame);
        _viewModel.NewGame += new EventHandler<int>(NewGame);
        _viewModel.GameOver += new EventHandler(GameOver);
        _viewModel.LoadGame += new EventHandler(LoadGame);

        MainPage = _appShell;
    }
    private void ExitGame(Object sender, EventArgs e)
    {
        Application.Current.Quit();
    }
    private void NewGame(Object sender, int s)
    {
        CreateGame(s);
    }
    private void GameOver(Object sender, EventArgs e)
    {
        string winner = _game.winner == players.HUNTER ? "Hunter" : "Prey";
        MainPage.DisplayAlert("The game is over", $"{winner} won the game", "ok");
        CreateGame(_game.size);
    }
    private async void LoadGame(object sender, EventArgs e)
    {
        var files = Directory.GetFiles(FileSystem.Current.AppDataDirectory).Select(x => Path.GetFileName(x).Split(".")[0]).ToArray();
        string fname = await MainPage.DisplayActionSheet("Choose a file","Cancel",null,files);
        if (fname == "Cancel")
        {
            return;
        }
        try
        {
            var path = FileSystem.Current.AppDataDirectory;
            CreateGame(Path.Combine(path,fname+".hnt"));
        }
        catch (Exception)
        {
            await MainPage.DisplayAlert("Error", $"There was an error while reading the file", "ok");
        }
    }
    private async void SaveGame(object sender, EventArgs e)
    {
        string fname = await MainPage.DisplayPromptAsync("File saving", "Name of file:");
        if (fname == null)
        {
            return;
        }
        try
        {
            var path = FileSystem.Current.AppDataDirectory;
            _game.save(Path.Combine(path,fname+".hnt"));
        }
        catch (Exception)
        {
            await MainPage.DisplayAlert("Error", $"There was an error while reading the file", "ok");
        }
    }
    private void DeleteSaves(object sender, EventArgs e)
    {
        foreach (var fname in Directory.GetFiles(FileSystem.AppDataDirectory))
        {
            File.Delete(fname);
        }
    }
}
