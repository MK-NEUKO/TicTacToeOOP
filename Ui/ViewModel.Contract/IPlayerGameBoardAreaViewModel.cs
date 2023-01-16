using System.Windows.Input;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayerGameBoardAreaViewModel
{
    ICommand AreaWasClickedCommand { get; set; }

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayerGameBoardAreaViewModel._id"/>
    int Id { get; set; }

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayerGameBoardAreaViewModel._token"/>
    string? Token { get; set; }

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayerGameBoardAreaViewModel._isWinArea"/>
    bool IsWinArea { get; set; }

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayerGameBoardAreaViewModel._isStartNewGameAnimation"/>
    bool IsStartNewGameAnimation { get; set; }

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayerGameBoardAreaViewModel._isStartSaveGameAnimation"/>
    bool IsStartSaveGameAnimation { get; set; }
}