using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayerViewModel
{
    void SetPoint();
    bool TryPlaceAToken(IPlayerGameBoardViewModel currentGameBoard, int clickedAreaId = 10);

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayerViewModel._name"/>
    string? Name { get; set; }

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayerViewModel._token"/>
    string? Token { get; set; }

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayerViewModel._isWinner"/>
    bool IsWinner { get; set; }

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayerViewModel._isHuman"/>
    bool IsHuman { get; set; }

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayerViewModel._isAi"/>
    bool IsAi { get; set; }

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayerViewModel._isPlayersTurn"/>
    bool IsPlayersTurn { get; set; }

    /// <inheritdoc cref="PlayerViewModel._points"/>
    int Points { get; set; }
}