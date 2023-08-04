using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class EvaluationResultForMinimax : IEvaluationResultForMinimax
{
    public int NodeRating { get; set; }
    public bool IsMovesLeft { get; set; }
}