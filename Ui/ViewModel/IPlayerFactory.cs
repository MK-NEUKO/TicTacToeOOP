namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public interface IPlayerFactory
{
    PlayerViewModel CreatePlayer(string token);
}