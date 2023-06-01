namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface IGameEvaluator
{
    Task<IEvaluationResult> EvaluateGameTaskAsync(List<string> gameBoard, string player);
    IEvaluationResultForMinimax EvaluateGameForMinimax(List<string> gameBoard, string player);
    string GetOpponentOf(string player);
}