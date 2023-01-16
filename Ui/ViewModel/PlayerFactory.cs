namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public class PlayerFactory : IPlayerFactory
{
    public PlayerViewModel CreatePlayer(string token)
    {
        var player = new PlayerViewModel(token);
        return player;
    }
}