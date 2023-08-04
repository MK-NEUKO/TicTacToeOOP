using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public class MainViewModel : IMainViewModel
{
    public MainViewModel(IPlayerGameBoardViewModel playerGameBoardViewModel,
                         IGameViewModel gameViewModel,
                         IMenuViewModel menuViewModel,
                         IGameInfoBoardViewModel gameInfoBoardViewModel)
    {
        PlayerGameBoardViewModel = playerGameBoardViewModel;
        MenuViewModel = menuViewModel;
        GameViewModel = gameViewModel;
        GameInfoBoardViewModel = gameInfoBoardViewModel;
    }

    public IPlayerGameBoardViewModel PlayerGameBoardViewModel { get; }
    public IMenuViewModel MenuViewModel { get; set; }
    public IGameViewModel GameViewModel { get; }
    public IGameInfoBoardViewModel GameInfoBoardViewModel { get; }
}