using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameMenuViewModel
{
    string? NamePlayerX { get; set; }
    string? NamePlayerO { get; set; }

    /// <inheritdoc cref="GameMenuViewModel._isAiPlayerX"/>
    bool IsAiPlayerX { get; set; }

    /// <inheritdoc cref="GameMenuViewModel._isHumanPlayerX"/>
    bool IsHumanPlayerX { get; set; }

    /// <inheritdoc cref="GameMenuViewModel._isPlayersTurnPlayerX"/>
    bool IsPlayersTurnPlayerX { get; set; }

    /// <inheritdoc cref="GameMenuViewModel._isWinnerPlayerX"/>
    bool IsWinnerPlayerX { get; set; }

    /// <inheritdoc cref="GameMenuViewModel._pointsPlayerX"/>
    int PointsPlayerX { get; set; }

    /// <inheritdoc cref="GameMenuViewModel._tokenPlayerX"/>
    string? TokenPlayerX { get; set; }

    /// <inheritdoc cref="GameMenuViewModel._isAiPlayerO"/>
    bool IsAiPlayerO { get; set; }

    /// <inheritdoc cref="GameMenuViewModel._isHumanPlayerO"/>
    bool IsHumanPlayerO { get; set; }

    /// <inheritdoc cref="GameMenuViewModel._isPlayersTurnPlayerO"/>
    bool IsPlayersTurnPlayerO { get; set; }

    /// <inheritdoc cref="GameMenuViewModel._isWinnerPlayerO"/>
    bool IsWinnerPlayerO { get; set; }

    /// <inheritdoc cref="GameMenuViewModel._pointsPlayerO"/>
    int PointsPlayerO { get; set; }

    /// <inheritdoc cref="GameMenuViewModel._tokenPlayerO"/>
    string? TokenPlayerO { get; set; }

    /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand"/> instance wrapping <see cref="GameMenuViewModel.StartGame"/>.</summary>
    global::CommunityToolkit.Mvvm.Input.IRelayCommand StartGameCommand { get; }

    /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand"/> instance wrapping <see cref="GameMenuViewModel.SetupDefaultPlayer"/>.</summary>
    global::CommunityToolkit.Mvvm.Input.IRelayCommand SetupDefaultPlayerCommand { get; }
}