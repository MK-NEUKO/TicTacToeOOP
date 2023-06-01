namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface IEvaluationResultForMinimax
{
    int NodeRating { get; set; }
    bool IsMovesLeft { get; set; }
}