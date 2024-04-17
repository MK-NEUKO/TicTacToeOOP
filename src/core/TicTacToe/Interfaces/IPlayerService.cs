namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IPlayerService
{
    /// <summary>
    /// Changes the IsCurrentPlayer property of each of the two players to the opposite of the current value.
    /// The "playerList" parameter must contain two players.
    /// </summary>
    /// <param name="playerList"></param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    void ChangeCurrentPlayer(List<IPlayer> playerList);
}