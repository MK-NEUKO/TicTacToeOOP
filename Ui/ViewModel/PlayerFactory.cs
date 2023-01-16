using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public class PlayerFactory : IPlayerFactory
{
    public IPlayerViewModel CreatePlayer(string token)
    {
        var player = new PlayerViewModel(token);
        return player;
    }
}