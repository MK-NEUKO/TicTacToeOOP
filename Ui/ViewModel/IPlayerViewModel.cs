namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public interface IPlayerViewModel
{
    string PlaceAToken();

    /// <inheritdoc cref="PlayerViewModel._name"/>
    string? Name { get; set; }

    /// <inheritdoc cref="PlayerViewModel._token"/>
    string? Token { get; set; }

    /// <inheritdoc cref="PlayerViewModel._isWinner"/>
    bool IsWinner { get; set; }

    /// <inheritdoc cref="PlayerViewModel._isHuman"/>
    bool IsHuman { get; set; }

    /// <inheritdoc cref="PlayerViewModel._isAi"/>
    bool IsAi { get; set; }
}