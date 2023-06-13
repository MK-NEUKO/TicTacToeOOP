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
        GameViewModel = gameViewModel;
        MenuViewModel = menuViewModel;
        GameInfoBoardViewModel = gameInfoBoardViewModel;
    }

    public IPlayerGameBoardViewModel PlayerGameBoardViewModel { get; }
    public IGameViewModel GameViewModel { get; }
    public IMenuViewModel MenuViewModel { get; set; }
    public IGameInfoBoardViewModel GameInfoBoardViewModel { get; }
}