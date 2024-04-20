namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IPlayerService
{
    /// <summary>
    /// Changes the IsCurrentPlayer property of each of the two players to the opposite of the current value.
    /// The "playerList" parameter must contain two players.
    /// </summary>
    void ChangeCurrentPlayer(List<IPlayer> playerList);
}