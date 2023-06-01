using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class EvaluationResultForForMinimax : IEvaluationResultForMinimax
{
    public int NodeRating { get; set; }
    public bool IsMovesLeft { get; set; }
}