using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public interface IPlayerGameBoardAreaViewModel
{
    int Id { get; }
    string? Token { get; set; }
    bool IsWinArea { get; set; }
    bool IsStartNewGameAnimation { get; set; }
    bool IsStartSaveGameAnimation { get; set; }
    ICommand AreaWasClickedCommand { get; set; }
}