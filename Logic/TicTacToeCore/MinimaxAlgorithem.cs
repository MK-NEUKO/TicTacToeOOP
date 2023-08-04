using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class MinimaxAlgorithm : IMinimaxAlgorithm
{
    private readonly IGameEvaluator _evaluator;
    private string _player;
    private string _opponent;

    public MinimaxAlgorithm(IGameEvaluator evaluator)
    {
        _evaluator = evaluator;
        _player = string.Empty;
        _opponent = string.Empty;
    }

    public int FindBestMove(List<string> gameBoard, string player)
    {
        var bestMove = -1;
        var bestNodeRating = int.MinValue;
        _player = player;
        _opponent = _evaluator.GetOpponentOf(player);

        for (var i = 0; i < gameBoard.Count; i++)
        {
            if (gameBoard[i] == string.Empty)
            {
                gameBoard[i] = _player;
                //var currentBoard = new List<string>(gameBoard);
                var currentNodeRating = Minimax(gameBoard, 0, false);
                gameBoard[i] = string.Empty;

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
    
    private int Minimax(List<string> gameBoard, int depth, bool isMaximizer)
    {

        var evaluationResult = _evaluator.EvaluateGameForMinimax(gameBoard, _player);

        // If Maximizer has won the game 
        // return his/her evaluated score
        if(evaluationResult.NodeRating == 100) return evaluationResult.NodeRating - depth;

        // If Minimizer has won the game 
        // return his/her evaluated score
        if(evaluationResult.NodeRating == -100) return evaluationResult.NodeRating + depth;

        // If there are no more moves and 
        // no winner then it is a tie
        if (evaluationResult.IsMovesLeft == false) return 0;

        // If this maximizer's move
        if (isMaximizer)
        {
            var bestNodeRating = int.MinValue;

            // Traverse all cells
            for (var i = 0; i < gameBoard.Count; i++)
            {
                // Check if cell is empty
                if (gameBoard[i] == string.Empty)
                {
                    // Make the move
                    gameBoard[i] = _player;

                    // Call minimax recursively and choose
                    // the maximum value
                    bestNodeRating = Math.Max(bestNodeRating, Minimax(gameBoard, depth + 1, !isMaximizer));

                    // Undo the move
                    gameBoard[i] = string.Empty;
                }
            }
            return bestNodeRating;
        }

        // If this minimizer's move
        else
        {
            var bestNodeRating = int.MaxValue;

            // Traverse all cells
            for (var i = 0; i < gameBoard.Count; i++)
            {
                // Check if cell is empty
                if (gameBoard[i] == string.Empty)
                {
                    // Make the move
                    gameBoard[i] = _opponent;
                    // Call minimax recursively and choose
                    // the minimum value
                    bestNodeRating = Math.Min(bestNodeRating, Minimax(gameBoard, depth + 1, !isMaximizer));

                    // Undo the move
                    gameBoard[i] = string.Empty;
                }
            }
            return bestNodeRating;
        }
    } 
}