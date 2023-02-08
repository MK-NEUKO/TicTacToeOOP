namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface IPlayer
{
    bool IsWinner { get; set; }
    string? Name { get; set; }
    int Points { get; set; }
    string? Token { get; set; }
    bool IsAi { get; set; }
    bool IsHuman { get; set; }
    bool IsPlayersTurn { get; set; }
}