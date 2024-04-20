using MichaelKoch.TicTacToe.Core.Interfaces;

namespace MichaelKoch.TicTacToe.Core.Services;

public class PlayerService : IPlayerService
{
    /// <summary>
    /// Changes the IsCurrentPlayer property of each of the two players to the opposite of the current value.
    /// The "playerList" parameter must contain two players.
    /// </summary>
    /// <param name="playerList"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public void ChangeCurrentPlayer(List<IPlayer> playerList)
    {
        if (playerList == null) throw new ArgumentNullException(nameof(playerList), "The Argument \"playerList\" is Null!");
        if(playerList.Count != 2) throw new ArgumentException("The Argument \"playerList\" must have two Players!", nameof(playerList));
        playerList.ForEach(p => p.IsCurrentPlayer = !p.IsCurrentPlayer);
    }
}
