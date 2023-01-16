namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public interface IGameBoardAreaFactory
{
    List<IPlayerGameBoardAreaViewModel> CreateAreas();
}