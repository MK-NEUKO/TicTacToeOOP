using System.Collections.Generic;

namespace NEUKO.TicTacToe.Core
{
    public interface IGameBoard
    {
        IList<GameBoardArea> BoardAreaList { get; }
        void PlaceASigne(int areaId);
        string CheckForWinner();
    }
}
