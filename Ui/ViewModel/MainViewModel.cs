using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public class MainViewModel : IMainViewModel
{
    public MainViewModel(IPlayerGameBoardViewModel playerGameBoardViewModel,
                         IGameViewModel gameViewModel,
                         IMenuViewModel menuViewModel,
                         IPlayingPlayerViewModel playingPlayerViewModel)
    {
        PlayerGameBoardViewModel = playerGameBoardViewModel;
        GameViewModel = gameViewModel;
        MenuViewModel = menuViewModel;
        PlayingPlayerViewModel = playingPlayerViewModel;
    }

    public IPlayerGameBoardViewModel PlayerGameBoardViewModel { get; }
    public IGameViewModel GameViewModel { get; }
    public IMenuViewModel MenuViewModel { get; set; }
    public IPlayingPlayerViewModel PlayingPlayerViewModel { get; }
}