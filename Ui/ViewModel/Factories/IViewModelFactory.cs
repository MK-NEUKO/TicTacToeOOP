namespace MichaelKoch.TicTacToe.Ui.ViewModel.Factories;

public interface IViewModelFactory<T>
{
    T Create();
}