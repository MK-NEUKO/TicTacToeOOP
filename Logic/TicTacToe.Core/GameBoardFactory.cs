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

            for (int index = 0; index < gameBoardAreas; index++)
            {
                _gameBoardAreaList.Add(new GameBoardArea(index));
                SetColumnRowIndex(index);
            }
            return new GameBoard(_gameBoardAreaList);
        }

        private void SetColumnRowIndex(int index)
        {
            int columns = 3;
            int rows = 3;

            for (int columnIndex = 0; columnIndex < columns; columnIndex++)
            {
                for (int rowIndex = 0; rowIndex < rows; rowIndex++)
                {
                    _gameBoardAreaList[index].ColumnIndex = columnIndex;
                    _gameBoardAreaList[index].RowIndex = rowIndex;
                }
            }
        }
    }
}
