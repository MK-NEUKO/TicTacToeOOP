namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IGameEvaluator
{
    void EvaluateGame(IGameBoard gameBoard, List<IPlayer> playerList);
    void EvaluateGameBoardBase(IGameBoard gameBoard, List<IPlayer> playerList);
    //string GetOpponentOf(string player);
    void DetermineWinner(IGameBoard gameBoard, List<IPlayer> playerList);
}