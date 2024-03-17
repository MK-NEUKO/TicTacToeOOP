using MichaelKoch.TicTacToe.Enums;

namespace MichaelKoch.TicTacToe.Entities;

public class Player
{
    public string Name { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public bool IsHuman { get; set; } = true;
    public bool IsAi { get; set; }
    public bool IsOnTheMove { get; set; }
    public bool IsWinner { get; set; }
    public int Score { get; set; }
    public AiDifficultyLevel AiDifficultyLevel { get; set; } = AiDifficultyLevel.Easy;
}