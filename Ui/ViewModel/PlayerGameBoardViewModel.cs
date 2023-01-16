namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public class PlayerGameBoardViewModel : IPlayerGameBoardViewModel
{
    public PlayerGameBoardViewModel(IGameBoardAreaFactory gameBoardAreaFactory)
    {
        Areas = gameBoardAreaFactory.CreateAreas();
    }

    public List<IPlayerGameBoardAreaViewModel> Areas { get; }
}