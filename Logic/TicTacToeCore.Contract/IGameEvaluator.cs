namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface IGameEvaluator
{
    Task<IEvaluationResult> EvaluateGameTaskAsync(List<string> tokenList, string playersToken);
    Task<IEvaluationResultMinimax> EvaluateGameForMinimaxTaskAsync(List<string> currentGameBoard, string player);
}