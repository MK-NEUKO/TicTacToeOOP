using MichaelKoch.TicTacToe.Core.Interfaces;
using System.Text.Json.Serialization;

namespace MichaelKoch.TicTacToe.Ui.AspNetCoreWebUI.Models;

public class SimplePlayer : IPlayer
{
    public string Name { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public bool IsHuman { get; set; }
    public bool IsAi { get; set; }
    public bool IsCurrentPlayer { get; set; }
    public bool IsWinner { get; set; }
    public bool IsLoser { get; set; }
    public int Score { get; set; }
    public MichaelKoch.TicTacToe.Core.Enums.AiDifficultyLevel AiDifficultyLevel { get; set; }
}

public class SimpleGameBoardArea : IGameBoardArea
{
    public int Id { get; set; }
    public string Token { get; set; } = string.Empty;
    public bool IsWinArea { get; set; }
    public bool IsOccupied { get; set; }
}

public class SimpleGameBoard : IGameBoard
{
    public List<SimpleGameBoardArea> ConcreteAreas { get; set; } = new();
    public bool IsUndecided { get; set; } = true;

    // This property is for interface compatibility only - exclude from JSON
    [JsonIgnore]
    public List<IGameBoardArea> Areas 
    { 
        get => ConcreteAreas.Cast<IGameBoardArea>().ToList();
        set => ConcreteAreas = value.Cast<SimpleGameBoardArea>().ToList();
    }

    public SimpleGameBoard()
    {
        // Initialize 9 areas for TicTacToe
        for (int i = 0; i < 9; i++)
        {
            ConcreteAreas.Add(new SimpleGameBoardArea { Id = i });
        }
    }
}