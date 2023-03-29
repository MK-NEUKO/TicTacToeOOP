using System.Windows.Input;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayerGameBoardAreaViewModel
{
    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._id"/>
    int Id { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._token"/>
    string? Token { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._isWinArea"/>
    bool IsWinArea { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._isOccupied"/>
    bool IsOccupied { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._isStartNewGameAnimation"/>
    bool IsStartNewGameAnimation { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._isStartSaveGameAnimation"/>
    bool IsStartSaveGameAnimation { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._isInGame"/>
    bool IsInGame { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._canShowIsOccupied"/>
    bool CanShowIsOccupied { get; set; }

    /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand"/> instance wrapping <see cref="PlayerGameBoardAreaViewModel.PlaceAToken"/>.</summary>
    global::CommunityToolkit.Mvvm.Input.IRelayCommand AreaWasClickedCommand { get; }

    /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand"/> instance wrapping <see cref="PlayerGameBoardAreaViewModel.MouseEnter"/>.</summary>
    global::CommunityToolkit.Mvvm.Input.IRelayCommand MouseEnterForShowIsOccupiedCommand { get; }

    void ResetToContinue();
}