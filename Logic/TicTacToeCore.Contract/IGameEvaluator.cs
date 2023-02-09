namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface IGameEvaluator
{
    IEvaluationResult EvaluateGame(List<string> tokenList, string currentToken);
}