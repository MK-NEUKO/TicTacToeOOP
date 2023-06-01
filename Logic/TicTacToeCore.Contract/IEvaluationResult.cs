namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface IEvaluationResult
{
    List<bool> WinAreas { get; set; }
    bool IsWinner { get; set; }
    bool IsLoser { get; set; }
    bool IsDraw { get; set; }
    bool IsMoveLeft { get; set; }
}