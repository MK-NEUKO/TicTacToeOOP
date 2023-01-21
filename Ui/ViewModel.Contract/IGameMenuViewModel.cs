using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameMenuViewModel
{
    IPlayerViewModel PlayerX { get; set; }
    IPlayerViewModel PlayerO { get; set; }
}