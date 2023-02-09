namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface IEvaluationResult
{
    List<bool> WinAreas { get; set; }
    bool IsWinner { get; set; }
    bool IsDraw { get; set; }
}