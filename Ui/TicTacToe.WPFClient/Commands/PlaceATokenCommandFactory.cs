using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public class PlaceATokenCommandFactory
    {
        private IList<PlaceATokenCommand> _placeATokenCommands;
        private readonly IMainWindowViewModel _mainWondowViewModel;

        public PlaceATokenCommandFactory(IList<PlaceATokenCommand> placeATokenCommands, IMainWindowViewModel mainWindowViewModel)
        {
            _mainWondowViewModel = mainWindowViewModel;
            _placeATokenCommands = placeATokenCommands;
        }

        public void CreateCommands()
        {
            int numberOfCommands = 9;

            for (int areaID = 0; areaID < numberOfCommands; areaID++)
            {
                _placeATokenCommands.Add(new PlaceATokenCommand(areaID, _mainWondowViewModel));
            }
            SetColumnRowIndex();
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
