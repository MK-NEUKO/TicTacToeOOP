using MichaelKoch.TicTacToe.Entities;
using MichaelKoch.TicTacToe.Interfaces;

namespace MichaelKoch.TicTacToe.Services;

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