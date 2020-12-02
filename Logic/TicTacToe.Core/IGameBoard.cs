using System.Collections.Generic;

namespace NEUKO.TicTacToe.Core
{
    public interface IGameBoard
    {
        IList<GameBoardArea> BoardAreaList { get; }
        bool PlayerXIsWinner { get; }
        bool PlayerOIsWinner { get; }
        bool GameIsTie { get; }
        void PlaceAToken(int areaID, string token);
        void CheckGameBoardState();
        void ResetGameBoard();
    }
}
