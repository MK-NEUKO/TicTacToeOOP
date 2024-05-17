using MichaelKoch.TicTacToe.Core.Interfaces;

namespace MichaelKoch.TicTacToe.Core.Services;

public class GameEvaluator : IGameEvaluator
{
      private readonly List<List<int>> _winPositions =
      [
          [0, 1, 2], /*  +---+---+---+  */
          [3, 4, 5], /*  | 0 | 1 | 2 |  */
          [6, 7, 8], /*  +---+---+---+  */
          [0, 3, 6], /*  | 3 | 4 | 5 |  */
          [1, 4, 7], /*  +---+---+---+  */
          [2, 5, 8], /*  | 6 | 7 | 8 |  */
          [0, 4, 8], /*  +---+---+---+  */
          [2, 4, 6]
      ];

    //public Task<IEvaluationResult> EvaluateGameTaskAsync(List<string> gameBoard, string player)
    //{
    //    var task = Task.Run<IEvaluationResult>(() => EvaluateGameBoardBase(gameBoard, player));
    //    return task;
    //}

    //public IEvaluationResultForMinimax EvaluateGameForMinimax(List<string> gameBoard, string player)
    //{
    //    var evaluationResult = EvaluateGameBoardBase(gameBoard, player);
    //    var evaluationResultForMinimax = new EvaluationResultForMinimax
    //    {
    //        IsMovesLeft = evaluationResult.IsMoveLeft
    //    };
    //    CreateCurrentNodeRating(evaluationResultForMinimax,  evaluationResult);

    //    return evaluationResultForMinimax;
    //}

    public void EvaluateGame(IGameBoard gameBoard, List<IPlayer> playerList)
    {
        EvaluateGameBoardBase(gameBoard, playerList);
    }

    public void EvaluateGameBoardBase(IGameBoard gameBoard, List<IPlayer> playerList)
    {
        ArgumentNullException.ThrowIfNull(gameBoard);
        ArgumentNullException.ThrowIfNull(playerList);
        DetermineWinner(gameBoard, playerList);
    }

    //private void CreateCurrentNodeRating(IEvaluationResultForMinimax evaluationResultForMinimax, IEvaluationResult evaluationResult)
    //{
    //    if (evaluationResult.IsWinner) evaluationResultForMinimax.NodeRating = 100;
    //    if (evaluationResult.IsLoser) evaluationResultForMinimax.NodeRating = -100;
    //    if (evaluationResult.IsDraw) evaluationResultForMinimax.NodeRating = 0;
    //}

    //public string GetOpponentOf(string player)
    //{
    //    return player switch
    //    {
    //        "X" => "O",
    //        "O" => "X",
    //        _ => throw new NotSupportedException("GetOpponentOf")
    //    };
    //}

    public void DetermineWinner(IGameBoard gameBoard, List<IPlayer> playerList)
    {
        var currentPlayer = playerList.FirstOrDefault(p => p.IsCurrentPlayer);
        var opponent = playerList.FirstOrDefault(p => !p.IsCurrentPlayer);
        var threeTimesPlayerToken = new string(Convert.ToChar(currentPlayer.Token), 3);
        var threeTimesOpponentToken = new string(Convert.ToChar(opponent.Token), 3);

        foreach (var winPosition in _winPositions)
        {
            var currentContent = string.Empty;
            winPosition.ForEach(i => currentContent += gameBoard.Areas[i].Token);

            if (currentContent == threeTimesPlayerToken)
            {
                currentPlayer.IsWinner = true;
                winPosition.ForEach(i => gameBoard.Areas[i].IsWinArea = true);
                return;
            }

            if (currentContent == threeTimesOpponentToken)
            {
                currentPlayer.IsLoser = true;
                return;
            }

        }

        if(gameBoard.Areas.All(area => area.IsOccupied))
        {
            gameBoard.IsUndecided = true;
        }
    }
}