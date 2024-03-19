using MichaelKoch.TicTacToe.Core.Entities;

namespace MichaelKoch.TicTacToe.Samples.ViewModel;

public class PlayerViewModel
{
    public string FirstInfoRowLabel { get; set; } = "test";

    public Player PlayerO { get; set; }

    public PlayerViewModel()
    {
        PlayerO = new Player
        {
            Name = "Player O",
            IsWinner = false,
            IsAi = true,
            IsOnTheMove = true
        };
    }

}