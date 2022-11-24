using System;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient.SampleData
{
    public class RelayCommandDummy : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommandDummy(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommandDummy(Action<object> execute, Func<bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
