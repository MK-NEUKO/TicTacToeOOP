using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class EvaluationResultMinimax : IEvaluationResultMinimax
{
    public int NodeRating { get; set; }
    public bool IsMovesLeft { get; set; }
}