using System.Collections.Generic;

namespace NEUKO.TicTacToe.Core
{
    public interface IGameBoard
    {
        IList<GameBoardArea> BoardAreaList { get; }
        bool PlayerXIsWinner { get; }
        bool PlayerOIsWinner { get; }
        void PlaceASigne(int areaId, string signe);
        void CheckForWinner();
    }
}
