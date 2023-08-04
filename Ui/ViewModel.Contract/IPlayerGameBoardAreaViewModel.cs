using CommunityToolkit.Mvvm.Input;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface  IPlayerGameBoardAreaViewModel
{
    int Id { get; set; }
    string Token { get; set; }
    bool IsWinArea { get; set; }
    bool IsOccupied { get; set; }
    bool IsStartNewGameAnimation { get; set; }
    bool IsStartSaveGameAnimation { get; set; }
    bool IsInGame { get; set; }
    bool CanShowIsOccupied { get; set; }
    IRelayCommand AreaWasClickedCommand { get; }
    IRelayCommand MouseEnterForShowIsOccupiedCommand { get; }
    void ResetToContinue();
    void ResetForNewGame();
}