using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface IMinimaxAlgorithm
{
    int FindBestMove(List<string> gameBoard, string player, AiDifficultyLevel difficultyLevel);
}