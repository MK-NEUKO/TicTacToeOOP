namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameBoardAreaFactory
{
    List<IPlayerGameBoardAreaViewModel> CreateAreas();
}