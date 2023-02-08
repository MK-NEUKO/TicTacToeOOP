namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface IGameBoardEvaluator
{
    bool[] DetermineWinner(List<string> tokenList, string currentToken);
}