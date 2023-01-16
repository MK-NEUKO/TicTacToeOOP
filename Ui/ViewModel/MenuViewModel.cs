namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public class MenuViewModel : IMenuViewModel
{
    public MenuViewModel(IGameMenuViewModel gameMenuViewModel)
    {
        GameMenuViewModel = gameMenuViewModel;
    }

    public IGameMenuViewModel GameMenuViewModel { get; set; }
}