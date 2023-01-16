using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public interface IPlayerGameBoardAreaViewModel
{
    ICommand AreaWasClickedCommand { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._id"/>
    int Id { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._token"/>
    string? Token { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._isWinArea"/>
    bool IsWinArea { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._isStartNewGameAnimation"/>
    bool IsStartNewGameAnimation { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._isStartSaveGameAnimation"/>
    bool IsStartSaveGameAnimation { get; set; }
}