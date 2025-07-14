namespace MichaelKoch.TicTacToe.Ui.AspNetCoreWebUI.Models;

public class GameViewModel
{
    public SimpleGameBoard GameBoard { get; set; } = new();
    public List<SimplePlayer> Players { get; set; } = new();
    public string CurrentPlayerToken { get; set; } = "X";
    public string GameStatus { get; set; } = "Game in progress";
    public bool GameEnded { get; set; }
    public string? WinnerName { get; set; }

    public GameViewModel()
    {
        // Initialize players
        Players.Add(new SimplePlayer 
        { 
            Name = "Player 1", 
            Token = "X", 
            IsHuman = true, 
            IsCurrentPlayer = true 
        });
        Players.Add(new SimplePlayer 
        { 
            Name = "Player 2", 
            Token = "O", 
            IsHuman = true, 
            IsCurrentPlayer = false 
        });
    }

    public SimplePlayer GetCurrentPlayer()
    {
        return Players.First(p => p.IsCurrentPlayer);
    }

    public void SwitchPlayer()
    {
        foreach (var player in Players)
        {
            player.IsCurrentPlayer = !player.IsCurrentPlayer;
        }
        CurrentPlayerToken = GetCurrentPlayer().Token;
    }
}