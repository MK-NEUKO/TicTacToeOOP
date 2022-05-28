using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public interface IMenuViewModel
    {
        public ICommand StartGameCommand { get; }
    }
}
