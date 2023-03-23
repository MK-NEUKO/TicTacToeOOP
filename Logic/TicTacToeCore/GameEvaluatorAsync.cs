using System.Reflection.Metadata.Ecma335;
using CommunityToolkit.Mvvm.ComponentModel.__Internals;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class GameEvaluator : IGameEvaluator
{
    private readonly int[,] _winConstellations;

    public GameEvaluator()
    {
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

    public async Task<IEvaluationResult> EvaluateGameTaskAsync(List<string> tokenList, string currentToken)
    {
        if (tokenList == null) throw new ArgumentNullException(nameof(tokenList));
        if (currentToken == null) throw new ArgumentNullException(nameof(currentToken));
        var evaluationResult = new EvaluationResult();
        await DetermineWinnerAsync(tokenList, currentToken, evaluationResult);
        await DetermineDrawAsync(tokenList, evaluationResult);

        return evaluationResult;
    }

    private async Task DetermineWinnerAsync(IReadOnlyList<string> tokenList, string currentToken, EvaluationResult evaluationResult)
    {
        await Task.Run(() =>
        {
            var numberOfConstellations = _winConstellations.GetLength(0);
            var referenceString = new string(Convert.ToChar(currentToken), 3);
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
            }
        });
    }

    private async Task DetermineDrawAsync(IReadOnlyList<string> tokenList, EvaluationResult evaluationResult)
    {
        await Task.Run(() =>
        {
            if (evaluationResult.IsWinner) return;
            if (tokenList.Contains(string.Empty)) return;
            evaluationResult.IsDraw = true;
        });
    }
}