using System.Diagnostics;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class GameEvaluator : IGameEvaluator
{
    private readonly List<List<int>> _winPositions;

    public GameEvaluator()
    {
        _winPositions = new List<List<int>>
        {
            new List<int>{0,1,2},   /*  +---+---+---+  */
            new List<int>{3,4,5},   /*  | 0 | 1 | 2 |  */
            new List<int>{6,7,8},   /*  +---+---+---+  */
            new List<int>{0,3,6},   /*  | 3 | 4 | 5 |  */
            new List<int>{1,4,7},   /*  +---+---+---+  */
            new List<int>{2,5,8},   /*  | 6 | 7 | 8 |  */
            new List<int>{0,4,8},   /*  +---+---+---+  */
            new List<int>{2,4,6}
        };
    }

    public Task<IEvaluationResult> EvaluateGameTaskAsync(List<string> gameBoard, string player)
    {
        var task = Task.Run<IEvaluationResult>(() =>
        {
            return EvaluateGameBoardBase(gameBoard, player);
        });
        return task;
    }

    public IEvaluationResultForMinimax EvaluateGameForMinimax(List<string> gameBoard, string player)
    {
        var evaluationResult = EvaluateGameBoardBase(gameBoard, player);
        var evaluationResultForMinimax = new EvaluationResultForForMinimax();
        evaluationResultForMinimax.IsMovesLeft = evaluationResult.IsMoveLeft;
        CreateCurrentNodeRating(evaluationResultForMinimax,  evaluationResult);

        return evaluationResultForMinimax;
    }

    private EvaluationResult EvaluateGameBoardBase(List<string> gameBoard, string player)
    {
        if (gameBoard == null) throw new ArgumentNullException(nameof(gameBoard));
        if (player == null) throw new ArgumentNullException(nameof(player));
        var evaluationResult = new EvaluationResult();
        DetermineGameBoardState(gameBoard, player, evaluationResult);
        return evaluationResult;
    }

    private void CreateCurrentNodeRating(IEvaluationResultForMinimax evaluationResultForMinimax, IEvaluationResult evaluationResult)
    {
        if (evaluationResult.IsWinner) evaluationResultForMinimax.NodeRating = 100;
        if (evaluationResult.IsLoser) evaluationResultForMinimax.NodeRating = -100;
        if (evaluationResult.IsDraw) evaluationResultForMinimax.NodeRating = 0;
    }

    public string GetOpponentOf(string player)
    {
        return player switch
        {
            "X" => "O",
            "O" => "X",
            _ => throw new NotSupportedException("GetOpponentOf")
        };
    }

    private void DetermineGameBoardState(IReadOnlyList<string> gameBoard, string player, EvaluationResult evaluationResult)
    {
        var threeTimesPlayer = new string(Convert.ToChar(player), 3);
        var threeTimesOpponent = new string(Convert.ToChar(GetOpponentOf(player)), 3);

        foreach (var winPosition in _winPositions)
        {
            var currentContent = string.Empty;
            winPosition.ForEach(i => currentContent += gameBoard[i]);

            if (currentContent == threeTimesPlayer)
            {
                evaluationResult.IsWinner = true;
                winPosition.ForEach(i => evaluationResult.WinAreas[i] = true);
                return;
            }

            if (currentContent == threeTimesOpponent)
            {
                evaluationResult.IsLoser = true;
                return;
            }
        }

        if(gameBoard.Contains(string.Empty))
        {
            evaluationResult.IsMoveLeft = true;
            return;
        }

        evaluationResult.IsDraw = true;
    }
}