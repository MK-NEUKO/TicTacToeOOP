namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IWindowService<T>
{
    void ShowDialog(object viewModel, Action<bool>? callback = null);
    void CloseDialog();
}