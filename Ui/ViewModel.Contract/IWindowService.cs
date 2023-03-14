using System.Windows;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IWindowService
{
    void ShowDialog(object viewModel);
}