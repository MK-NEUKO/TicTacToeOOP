using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    public class GameBoardFactory
    {
        private IList<GameBoardArea> _gameBoardAreaList;

        public GameBoardFactory(IList<GameBoardArea> gameBoardAreaList)
        {
            _gameBoardAreaList = gameBoardAreaList;
        }

        public GameBoard CreateGameBoard()
        {
            int gameBoardAreas = 9;            

            for (int areaID = 0; areaID < gameBoardAreas; areaID++)
            {
                _gameBoardAreaList.Add(new GameBoardArea(areaID));               
            }
            SetColumnRowIndex();
            return new GameBoard(_gameBoardAreaList);
        }

        private void SetColumnRowIndex()

        {
            int numberOfColumns = 3;
            int numberOfRows = 3;
            int listIndex = 0;

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int column = 0; column < numberOfColumns; column++)
                {
                    _gameBoardAreaList[listIndex].RowIndex = row;
                    _gameBoardAreaList[listIndex].ColumnIndex = column;
                    listIndex++;
                }
            }
        }
    }
}
