using MichaelKoch.TicTacToe.Core.Entities;

namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IGameEvaluator
{
    EvaluationResult EvaluateGame(IGameBoard gameBoard, List<IPlayer> players);
    EvaluationResult EvaluateGameBoardBase(IGameBoard gameBoard, List<IPlayer> playerList);
    //string GetOpponentOf(string player);
    void DetermineGameBoardState(IGameBoard gameBoard, List<IPlayer> playerList, EvaluationResult evaluationResult);
}