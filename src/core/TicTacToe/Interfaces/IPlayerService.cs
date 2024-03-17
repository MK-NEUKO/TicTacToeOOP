using MichaelKoch.TicTacToe.Entities;

namespace MichaelKoch.TicTacToe.Interfaces;

public interface IPlayerService
{
    List<Player> GetDefaultPlayerList();
}