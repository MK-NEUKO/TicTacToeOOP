namespace MichaelKoch.TicTacToe.Ui.ViewModel.Factories;

public interface IAbstractFactory<T>
{
    T Create();
}