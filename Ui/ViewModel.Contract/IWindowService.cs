namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IWindowService<T>
{
    void ShowDialog(object viewModel);
}