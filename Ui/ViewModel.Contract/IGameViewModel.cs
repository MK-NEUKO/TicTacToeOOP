namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameViewModel
{
    Task SaveGame();
    bool IsInGame { get; }
}