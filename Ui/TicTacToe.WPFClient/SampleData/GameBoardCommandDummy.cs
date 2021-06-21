using System;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient.SampleData
{
    public class GameBoardCommandDummy : ICommand
    {
        private int _rowIndex;
        private int _columnIndex;
        private readonly int _areaID;
        private readonly Action<int> _execute;
        private readonly Func<bool> _canExecute;

        public GameBoardCommandDummy(int areaID, Action<int> execute, Func<bool> canExecute)
        {
            _areaID = areaID;
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public int RowIndex { get => _rowIndex; set => _rowIndex = value; }
        public int ColumnIndex { get => _columnIndex; set => _columnIndex = value; }
        public int AreaID => _areaID;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute(_areaID);
        }

    }
}
