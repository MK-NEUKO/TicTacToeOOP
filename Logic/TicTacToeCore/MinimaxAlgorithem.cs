using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using System.ComponentModel;
using System.Xml.Linq;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class MinimaxAlgorithm : IMinimaxAlgorithm
{
    private string _player;
    private string _opponent;
    private GEvaluator evaluator = new GEvaluator();

    public int FindBestMove(List<string> board, string player)
    {
        var bestMove = -1;
        var bestNodeRating = int.MinValue;
        _player = player;
        _opponent = SetOpponent(player);

        for (var i = 0; i < board.Count; i++)
        {
            if (board[i] == string.Empty)
            {
                board[i] = _player;
                //var currentBoard = new List<string>(board);
                var currentNodeRating = Minimax(board, 0, false);
                //Console.WriteLine(currentNodeRating);
                board[i] = string.Empty;

                if (currentNodeRating > bestNodeRating)
                {
                    bestMove = i;
                    bestNodeRating = currentNodeRating;
                }
                //NodeList.Add(new Node{Depth = 0, NodeRating = currentNodeRating, Board = currentBoard, SetAreaId = i});
            }
        }

        return bestMove;
    }

    private string SetOpponent(string player) => player switch
    {
        "X" => "O",
        "O" => "X",
        _ => throw new InvalidOperationException(nameof(SetOpponent))
    };

    private int Minimax(List<string> board, int depth, bool isMaximizer)
    {

        var evaluationResult = evaluator.EvaluateGameState(board, _player);

        // If Maximizer has won the game 
        // return his/her evaluated score
        if(evaluationResult.NodeRating == 100) return evaluationResult.NodeRating - depth;

        // If Minimizer has won the game 
        // return his/her evaluated score
        if(evaluationResult.NodeRating == -100) return evaluationResult.NodeRating + depth;

        // If there are no more moves and 
        // no winner then it is a tie
        if (evaluationResult.IsMoveLeft == false) return 0;

        // If this maximizer's move
        if (isMaximizer)
        {
            var bestNodeRating = int.MinValue;

            // Traverse all cells
            for (var i = 0; i < board.Count; i++)
            {
                // Check if cell is empty
                if (board[i] == string.Empty)
                {
                    // Make the move
                    board[i] = _player;

                    // Call minimax recursively and choose
                    // the maximum value
                    bestNodeRating = Math.Max(bestNodeRating, Minimax(board, depth + 1, !isMaximizer));

                    // Undo the move
                    board[i] = string.Empty;
                }
            }
            return bestNodeRating;
        }

        // If this minimizer's move
        else
        {
            var bestNodeRating = int.MaxValue;

            // Traverse all cells
            for (var i = 0; i < board.Count; i++)
            {
                // Check if cell is empty
                if (board[i] == string.Empty)
                {
                    // Make the move
                    board[i] = _opponent;
                    // Call minimax recursively and choose
                    // the minimum value
                    bestNodeRating = Math.Min(bestNodeRating, Minimax(board, depth + 1, !isMaximizer));

                    // Undo the move
                    board[i] = string.Empty;
                }
            }
            return bestNodeRating;
        }
    } 
}

public class GEvaluator
{
    private readonly List<List<int>> _winPositions;

    public GEvaluator()
    {
        _winPositions = new List<List<int>>
        {
            new List<int> { 0, 1, 2 },
            new List<int> { 3, 4, 5 },
            new List<int> { 6, 7, 8 },
            new List<int> { 0, 3, 6 },
            new List<int> { 1, 4, 7 },
            new List<int> { 2, 5, 8 },
            new List<int> { 0, 4, 8 },
            new List<int> { 2, 4, 6 }
        };
    }

    public GameEvaluationResult EvaluateGameState(List<string> board, string player)
    {
        var result = new GameEvaluationResult();
        var opponet = GetOpponent(player);
        result.NodeRating = GetNodeRating(board, player, opponet);
        result.IsMoveLeft = GetIsMoveLeft(board, result);
        result.IsDraw = GetIsDraw(result);

        return result;
    }


    private string GetOpponent(string player) => player switch
    {
		"X" => "O",
		"O" => "X",
		_ => throw new InvalidOperationException(nameof(GetOpponent))
    };

    private int GetNodeRating(List<string> board, string player, string opponent)
    {
        var threeTimesPlayerToken = new string(Convert.ToChar(player), 3);
        var threeTimesOpponentToken = new string(Convert.ToChar(opponent), 3);

        foreach (var winPosition in _winPositions)
        {
            var currentContent = string.Empty;
            winPosition.ForEach(i => currentContent += board[i]);
            if (currentContent == threeTimesPlayerToken) return 100;
            if(currentContent == threeTimesOpponentToken) return -100;
        }
        return 0;
    }

    private bool GetIsDraw(GameEvaluationResult result)
    {
        if (!result.IsMoveLeft && result.NodeRating == 0) return true;

        return false;
    }

    private bool GetIsMoveLeft(List<string> board, GameEvaluationResult result)
    {
        foreach (var area in board)
        {
            if(area == string.Empty && result.NodeRating == 0) return true;
        }
        return false;
    }
}


public class GameEvaluationResult
{
    public int NodeRating { get; set; }
    public bool IsDraw { get; set; }
    public bool IsMoveLeft { get; set; }
}