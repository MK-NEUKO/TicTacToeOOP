using System.Reflection.Metadata.Ecma335;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class GameEvaluator : IGameEvaluator
{
    private readonly int[,] _winConstellations;
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

        _winConstellations = new int[8, 3]
        {
            {0,1,2}, /*  +---+---+---+  */
            {3,4,5}, /*  | 0 | 1 | 2 |  */
            {6,7,8}, /*  +---+---+---+  */
            {0,3,6}, /*  | 3 | 4 | 5 |  */
            {1,4,7}, /*  +---+---+---+  */
            {2,5,8}, /*  | 6 | 7 | 8 |  */
            {0,4,8}, /*  +---+---+---+  */
            {2,4,6},
        };
    }

    public async Task<IEvaluationResult> EvaluateGameTaskAsync(List<string> tokenList, string playersToken)
    {
        if (tokenList == null) throw new ArgumentNullException(nameof(tokenList));
        if (playersToken == null) throw new ArgumentNullException(nameof(playersToken));
        var evaluationResult = new EvaluationResult();
        await DetermineGameBoardStateAsync(tokenList, playersToken, evaluationResult);

        return evaluationResult;
    }

    public async Task<IEvaluationResultMinimax> EvaluateGameForMinimaxTaskAsync(List<string> currentGameBoard, string player)
    {
        var evaluationResult = await EvaluateGameTaskAsync(currentGameBoard, player);
        var evaluationResultMinimax = new EvaluationResultMinimax();
        evaluationResultMinimax.IsMovesLeft = evaluationResult.IsOpen;
        evaluationResultMinimax.NodeRating = CalculateCurrentNodeRating(evaluationResult);

        return evaluationResultMinimax;
    }

    private int CalculateCurrentNodeRating(IEvaluationResult evaluationResult)
    {
        if (evaluationResult.IsWinner) return 10;
        if (evaluationResult.IsDraw) return 0;
        if (evaluationResult.IsLoser) return -10;
        return 404;
    }

    private async Task DetermineGameBoardStateAsync(IReadOnlyList<string> tokenList, string playersToken, EvaluationResult evaluationResult)
    {
        await Task.Run(() =>
        {
            var numberOfConstellations = _winConstellations.GetLength(0);
            var referenceString = new string(Convert.ToChar(playersToken), 3);
            for (var i = 0; i < numberOfConstellations; i++)
            {
                var currentContent = tokenList[_winConstellations[i, 0]];
                currentContent += tokenList[_winConstellations[i, 1]];
                currentContent += tokenList[_winConstellations[i, 2]];

                if (currentContent != referenceString) continue;
                evaluationResult.WinAreas[_winConstellations[i, 0]] = true;
                evaluationResult.WinAreas[_winConstellations[i, 1]] = true;
                evaluationResult.WinAreas[_winConstellations[i, 2]] = true;
                evaluationResult.IsWinner = true;

                var opponentReferenceString = GetOpponentReferenceString(referenceString);
                if(currentContent != opponentReferenceString) continue;
                evaluationResult.IsLoser = true;
            }

            DetermineDrawAsync(tokenList, evaluationResult);
            DetermineOpenGameAsync(evaluationResult);
        });
    }

    private string GetOpponentReferenceString(string referenceString)
    {
        return referenceString switch
        {
            "XXX" => "OOO",
            "OOO" => "XXX",
            _ => throw new NotSupportedException("GetOpponentReferenceString")
        };
    }

    private void DetermineDrawAsync(IReadOnlyList<string> tokenList, EvaluationResult evaluationResult)
    {
        if (evaluationResult.IsWinner) return;
        if (tokenList.Contains(string.Empty)) return;
        evaluationResult.IsDraw = true;
    }

    private void DetermineOpenGameAsync(EvaluationResult evaluationResult)
    {
        if(evaluationResult.IsDraw) return;
        evaluationResult.IsOpen = true;
    }
}