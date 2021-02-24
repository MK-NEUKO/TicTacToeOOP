using System.Collections.Generic;

namespace NEUKO.TicTacToe.Core
{
    public interface IGameBoard
    {
        IList<GameBoardArea> BoardAreaList { get; }
        bool IsPlayerXWinner { get; }
        bool IsPlayerOWinner { get; }
        bool IsGameTie { get; }
        void PlaceAToken(int areaID, string token);
        void CheckGameBoardState();
        void ResetGameBoard();
    }
}
