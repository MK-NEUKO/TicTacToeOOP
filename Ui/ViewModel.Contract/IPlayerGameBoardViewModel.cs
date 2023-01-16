namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayerGameBoardViewModel
{
    List<IPlayerGameBoardAreaViewModel> Areas { get; }
}