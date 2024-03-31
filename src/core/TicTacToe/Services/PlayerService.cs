using MichaelKoch.TicTacToe.Core.Interfaces;

namespace MichaelKoch.TicTacToe.Core.Services;

public class PlayerService : IPlayerService
{
    public PlayerService()
    {
    }


    public async Task ChangeIsOnTheMove(IPlayer player, IPlayer opponent)
    {
        player.Name = "Sleepy";
        await Task.Delay(1000);
        player.Name = "Grumpy";
        await Task.Delay(1000);
        player.Name = "Dopey";
    }
}
