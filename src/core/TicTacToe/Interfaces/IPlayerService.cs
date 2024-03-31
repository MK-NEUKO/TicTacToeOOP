namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IPlayerService
{
    Task ChangeIsOnTheMove(IPlayer player, IPlayer opponent);
}