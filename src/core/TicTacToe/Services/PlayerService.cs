using MichaelKoch.TicTacToe.Core.Entities;
using MichaelKoch.TicTacToe.Core.Interfaces;

namespace MichaelKoch.TicTacToe.Core.Services;

public class PlayerService : IPlayerService
{
    private Player _playerX;
    private Player _playerO;

    public PlayerService()
    {
        _playerX = new Player();
        _playerO = new Player();
    }

    public Player PlayerX => _playerX;
    public Player PlayerO => _playerO;

    public Player GetDefaultPlayer()
    {
        return new Player
        {
            Name = "Player",
            Token = ""
        };
    }

    public void ChangeIsOnTheMove(Player player1, Player player2)
    {
        player1.IsOnTheMove = !player1.IsOnTheMove;
        player2.IsOnTheMove = !player2.IsOnTheMove;
        player2.Name = "Name";
    }
}