using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public class MainViewModel
{
    public MainViewModel(IPlayerGameBoardViewModel playerGameBoardViewModel, IGameViewModel gameViewModel, IMenuViewModel menuViewModel)
    {
        PlayerGameBoardViewModel = playerGameBoardViewModel;
        GameViewModel = gameViewModel;
        MenuViewModel = menuViewModel;
    }

    public IPlayerGameBoardViewModel PlayerGameBoardViewModel { get; }
    public IGameViewModel GameViewModel { get; }
    public IMenuViewModel MenuViewModel { get; set; }
}