namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface IEvaluationResultMinimax
{
    int NodeRating { get; set; }
    bool IsMovesLeft { get; set; }
}