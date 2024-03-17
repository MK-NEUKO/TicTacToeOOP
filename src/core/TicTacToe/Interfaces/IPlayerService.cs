using MichaelKoch.TicTacToe.Core.Entities;

namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IPlayerService
{
    List<Player> GetDefaultPlayerList();
}