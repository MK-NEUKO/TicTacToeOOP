namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface IGameEvaluator
{
    Task<IEvaluationResult> EvaluateGameTaskAsync(List<string> tokenList, string currentToken);
}