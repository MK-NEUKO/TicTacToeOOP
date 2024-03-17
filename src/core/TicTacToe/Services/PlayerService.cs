using MichaelKoch.TicTacToe.Core.Entities;
using MichaelKoch.TicTacToe.Core.Interfaces;

namespace MichaelKoch.TicTacToe.Core.Services;

public class PlayerService : IPlayerService  
{
    public List<Player> GetDefaultPlayerList()
    {
        return new List<Player>
        {
            new Player
            {
                Name = "Player X",
                Token = "X"
            },
            new Player
            {
                Name = "Player O",
                Token = "O"
            }
        };
    }
}