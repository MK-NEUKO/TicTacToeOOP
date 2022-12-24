namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public interface IPlayerGameBoardAreaViewModel
{
    /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand"/> instance wrapping <see cref="PlayerGameBoardAreaViewModel.AreaWasClicked"/>.</summary>
    global::CommunityToolkit.Mvvm.Input.IRelayCommand AreaWasClickedCommand { get; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._id"/>
    int Id { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._token"/>
    string Token { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._isWinArea"/>
    bool IsWinArea { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._isStartNewGameAnimation"/>
    bool IsStartNewGameAnimation { get; set; }

    /// <inheritdoc cref="PlayerGameBoardAreaViewModel._isStartSaveGameAnimation"/>
    bool IsStartSaveGameAnimation { get; set; }
}