using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NEUKO.TicTacToe.WPFClient
{
    public class PlaceATokenCommand : ICommand
    {
        private int _rowIndex;
        private int _columnIndex;

        public PlaceATokenCommand()
        {           
        }

        public int RowIndex { get => _rowIndex; set => _rowIndex = value; }
        public int ColumnIndex { get => _columnIndex; set => _columnIndex = value; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
