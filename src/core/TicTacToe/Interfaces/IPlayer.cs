using MichaelKoch.TicTacToe.Core.Enums;

namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IPlayer
{
    string Name { get; set; }
    string Token { get; set; }
    bool IsHuman { get; set; }
    bool IsAi { get; set; }
    bool IsOnTheMove { get; set; }
    bool IsWinner { get; set; }
    int Score { get; set; }
    AiDifficultyLevel AiDifficultyLevel { get; set; }
}