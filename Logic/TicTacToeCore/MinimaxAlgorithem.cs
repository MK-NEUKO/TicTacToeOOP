namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class MinimaxAlgorithem
{
//    // Evaluate the value of a game state for a player
//int Evaluate(GameState state, Player player)
//{
//    // TODO: implement your evaluation function here
//    // For example, return 1 if player wins, -1 if player loses, 0 if draw
//}

//// Generate the possible moves for a player from a game state
//List<Move> GenerateMoves(GameState state, Player player)
//{
//    // TODO: implement your move generation function here
//    // For example, return a list of valid moves for the player
//}

//// Negamax algorithm with alpha-beta pruning
//int Negamax(GameState state, Player player, int depth, int alpha, int beta)
//{
//    // If the game is over or the depth limit is reached, return the value of the state
//    if (state.IsGameOver() || depth == 0)
//    {
//        return Evaluate(state, player);
//    }

//    // Initialize the best value to negative infinity
//    int bestValue = int.MinValue;

//    // Loop through all possible moves for the player
//    foreach (Move move in GenerateMoves(state, player))
//    {
//        // Apply the move to get the new state
//        GameState newState = state.ApplyMove(move);

//        // Call negamax recursively for the opponent with the negated alpha and beta values
//        int value = -Negamax(newState, player.Opponent(), depth - 1, -beta, -alpha);

//        // Undo the move to restore the original state
//        state.UndoMove(move);

//        // Update the best value and alpha value
//        bestValue = Math.Max(bestValue, value);
//        alpha = Math.Max(alpha, value);

//        // If alpha is greater than or equal to beta, prune the remaining moves
//        if (alpha >= beta)
//        {
//            break;
//        }
//    }

//    // Return the best value
//    return bestValue;
//}

//// Find the best move for a player from a game state using negamax algorithm
//Move FindBestMove(GameState state, Player player, int depth)
//{
//    // Initialize the best move to null and the best value to negative infinity
//    Move bestMove = null;
//    int bestValue = int.MinValue;

//    // Loop through all possible moves for the player
//    foreach (Move move in GenerateMoves(state, player))
//    {
//        // Apply the move to get the new state
//        GameState newState = state.ApplyMove(move);

//        // Call negamax recursively for the opponent with a large negative and positive value for alpha and beta
//        int value = -Negamax(newState, player.Opponent(), depth - 1, int.MinValue, int.MaxValue);

//        // Undo the move to restore the original state
//        state.UndoMove(move);

//        // Update the best move and best value if the current value is better
//        if (value > bestValue)
//        {
//            bestMove = move;
//            bestValue = value;
//        }
//    }

//    // Return the best move
//    return bestMove;
//}
}