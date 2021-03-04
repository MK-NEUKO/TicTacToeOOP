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
        private int _areaID;
        private MainWindowViewModel _mainWindowViewModel;

        public PlaceATokenCommand(int areaID, MainWindowViewModel mainWindowViewModel)
        {
            _areaID = areaID;
            _mainWindowViewModel = mainWindowViewModel;
        }

        public int RowIndex { get => _rowIndex; set => _rowIndex = value; }
        public int ColumnIndex { get => _columnIndex; set => _columnIndex = value; }
        public int AreaID { get => _areaID; set => _areaID = value; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mainWindowViewModel.PlayAMove(_areaID);
        }
    }
}
