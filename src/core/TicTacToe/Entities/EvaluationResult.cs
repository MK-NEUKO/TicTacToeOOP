namespace MichaelKoch.TicTacToe.Core.Entities;

public class EvaluationResult
{
    public bool IsWinner { get; set; }
    public bool IsLoser { get; set; }
    public bool IsDraw { get; set; }
    public bool IsMoveLeft { get; set; }
}