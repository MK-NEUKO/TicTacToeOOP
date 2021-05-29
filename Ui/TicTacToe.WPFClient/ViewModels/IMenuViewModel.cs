using System.Windows.Input;

namespace NEUKO.TicTacToe.WPFClient
{
    public interface IMenuViewModel
    {
        public ICommand StartGameCommand { get; }
    }
}
