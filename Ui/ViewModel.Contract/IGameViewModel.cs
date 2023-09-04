namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameViewModel
{
    void SaveGame();
    bool IsInGame { get; }
}