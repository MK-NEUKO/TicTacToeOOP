using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class GameBoardEvaluator : IGameBoardEvaluator
{
    private readonly int[,] _winConstellations;

    public GameBoardEvaluator()
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

    public bool[] DetermineWinner(List<string> tokenList, string currentToken)
    {
        if (tokenList == null) throw new ArgumentNullException(nameof(tokenList));
        if (currentToken == null) throw new ArgumentNullException(nameof(currentToken));

        var result = new bool[10];
        var numberOfConstellations = _winConstellations.GetLength(0);
        var referenceString = new string(Convert.ToChar(currentToken), 3);
        for (var i = 0; i < numberOfConstellations; i++)
        {
            var currentContent = tokenList[_winConstellations[i, 0]];
            currentContent += tokenList[_winConstellations[i, 1]];
            currentContent += tokenList[_winConstellations[i, 2]];

            if (currentContent != referenceString) continue;
            result[_winConstellations[i, 0]] = true;
            result[_winConstellations[i, 1]] = true;
            result[_winConstellations[i, 2]] = true;
            result[9] = true;
        }
        return result;
    }
}