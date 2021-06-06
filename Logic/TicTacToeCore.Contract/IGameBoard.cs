using System.Collections.Generic;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract
{
    public interface IGameBoard
    {
        List<GameBoardArea> GetNewGameBoard();
        IReadOnlyList<GameBoardArea> GameBoardAreaList { get; }
        bool IsPlayerXWinner { get; }
        bool IsPlayerOWinner { get; }
        bool IsGameTie { get; }
        void PlaceAToken(int areaID, string token);
        void CheckGameBoardState();
        void ResetGameBoard();
        void ShowStartAnimation();
    }
}
