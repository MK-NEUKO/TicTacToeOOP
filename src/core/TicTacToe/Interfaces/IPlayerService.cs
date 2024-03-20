using MichaelKoch.TicTacToe.Core.Entities;

namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IPlayerService
{
    Player GetDefaultPlayer();
    void ChangeIsOnTheMove(Player player1, Player player2);
    Player PlayerX { get; }
    Player PlayerO { get; }
}