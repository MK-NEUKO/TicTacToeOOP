using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{ 
    public class PlaceATokenCommand : ICommand
    {
        private int _rowIndex;
        private int _columnIndex;
        private readonly int _areaID;
        private IMainWindowViewModel _mainWindowViewModel;

        public PlaceATokenCommand(int areaID, IMainWindowViewModel mainWindowViewModel)
        {
            _areaID = areaID;
            _mainWindowViewModel = mainWindowViewModel;
        }

        public int RowIndex { get => _rowIndex; set => _rowIndex = value; }
        public int ColumnIndex { get => _columnIndex; set => _columnIndex = value; }
        public int AreaID { get => _areaID; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mainWindowViewModel.PlayAMove(AreaID);
        }
    }
}
