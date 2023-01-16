namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayerFactory
{
    IPlayerViewModel CreatePlayer(string token);
}