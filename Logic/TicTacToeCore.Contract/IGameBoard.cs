using System.Collections.Generic;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract
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
