using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public interface IMenuViewModel
    {
        public ICommand StartGameCommand { get; }
        bool UserChoosesStartNewGame { get; set; }
        bool UserChoosesStartLastGame { get; set; }
    }
}
