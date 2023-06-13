namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IMainViewModel
{
    IPlayerGameBoardViewModel PlayerGameBoardViewModel { get; }
    IGameViewModel GameViewModel { get; }
    IMenuViewModel MenuViewModel { get; set; }
    IGameInfoBoardViewModel GameInfoBoardViewModel { get; }
}