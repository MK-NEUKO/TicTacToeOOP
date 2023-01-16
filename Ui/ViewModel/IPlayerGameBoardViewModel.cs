namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public interface IPlayerGameBoardViewModel
{
    List<IPlayerGameBoardAreaViewModel> Areas { get; }
}