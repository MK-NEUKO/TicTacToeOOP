using MichaelKoch.TicTacToe.Core.Enums;
using MichaelKoch.TicTacToe.Core.Interfaces;

namespace TicTacToe.Tests;

public class FakePlayer : IPlayer
{
    public string Name { get; set; } = "Player";
    public string Token { get; set; } = string.Empty;
    public bool IsHuman { get; set; }
    public bool IsAi { get; set; }
    public bool IsCurrentPlayer { get; set; }
    public bool IsWinner { get; set; }
    public int Score { get; set; }
    public AiDifficultyLevel AiDifficultyLevel { get; set; }
}