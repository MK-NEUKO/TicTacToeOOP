using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient
{
    public class PlaceATokenCommandFactory
    {
        private IList<PlaceATokenCommand> _placeATokenCommands;
        private MainWindowViewModel _mainWindowViewModel;

        public PlaceATokenCommandFactory(IList<PlaceATokenCommand> placeATokenCommands, MainWindowViewModel mainWindowViewModel)
        {
            _placeATokenCommands = placeATokenCommands;
            _mainWindowViewModel = mainWindowViewModel;
        }

        public List<PlaceATokenCommand> CreateCommands()
        {
            int numberOfCommands = 9;

            for (int areaID = 0; areaID < numberOfCommands; areaID++)
            {
                _placeATokenCommands.Add(new PlaceATokenCommand(areaID, _mainWindowViewModel));
            }
            SetColumnRowIndex();
            return (List<PlaceATokenCommand>)_placeATokenCommands;
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
