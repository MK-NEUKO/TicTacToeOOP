using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient
{
    public class PlaceATokenCommandFactory
    {
        private readonly List<PlaceATokenCommand> _placeATokenCommands;

        public PlaceATokenCommandFactory()
        {
            _placeATokenCommands = new List<PlaceATokenCommand>();
        }

        public List<PlaceATokenCommand> CreateCommands()
        {
            int numberOfCommands = 9;

            for (int i = 0; i < numberOfCommands; i++)
            {
                _placeATokenCommands.Add(new PlaceATokenCommand());
            }
            SetColumnRowIndex();
            return _placeATokenCommands;
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
                    _placeATokenCommands[listIndex].RowIndex = row;
                    _placeATokenCommands[listIndex].ColumnIndex = column;
                    listIndex++;
                }
            }
        }
    }
}
