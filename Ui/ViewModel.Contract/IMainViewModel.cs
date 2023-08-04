namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IMainViewModel
{
    IPlayerGameBoardViewModel PlayerGameBoardViewModel { get; }
    IMenuViewModel MenuViewModel { get; set; }
    IGameViewModel GameViewModel { get; }
    IGameInfoBoardViewModel GameInfoBoardViewModel { get; }
}