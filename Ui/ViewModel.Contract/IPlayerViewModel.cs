using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayerViewModel
{
    string PlaceAToken();

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
}