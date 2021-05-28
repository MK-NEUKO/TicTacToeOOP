using MichaelKoch.TicTacToe.Data.DataStoring.Contarct;
using System.Collections.Generic;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore
{
    public class GameBoardFactory
    {
        private readonly IGameBoardRepository _gameBoardRepository;

        public GameBoardFactory(IGameBoardRepository gameBoardRepository)
        {
            _gameBoardRepository = gameBoardRepository;
        }

        //public GameBoard CreateGameBoard()
        //{
        //    var gameBoardAreaList = _gameBoardRepository.GameBoardAreaList;
        //    int numberOfColumns = 3;
        //    int numberOfRows = 3;
        //    int listIndex = 0;

        //    for (int row = 0; row < numberOfRows; row++)
        //    {
        //        for (int column = 0; column < numberOfColumns; column++)
        //        {
        //            gameBoardAreaList[listIndex].RowIndex = row;
        //            gameBoardAreaList[listIndex].ColumnIndex = column;
        //            listIndex++;
        //        }
        //    }
        //    return new GameBoard(gameBoardAreaList);
        //}       
    }
}
