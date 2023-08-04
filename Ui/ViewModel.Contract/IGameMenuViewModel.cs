using CommunityToolkit.Mvvm.Input;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameMenuViewModel
{
    string? NamePlayerX { get; set; }
    string? NamePlayerO { get; set; }
    bool IsAiPlayerX { get; set; }
    bool IsHumanPlayerX { get; set; }
    bool IsPlayersTurnPlayerX { get; set; }
    bool IsWinnerPlayerX { get; set; }
    int PointsPlayerX { get; set; }
    string? TokenPlayerX { get; set; }
    bool IsAiPlayerO { get; set; }
    bool IsHumanPlayerO { get; set; }
    bool IsPlayersTurnPlayerO { get; set; }
    bool IsWinnerPlayerO { get; set; }
    int PointsPlayerO { get; set; }
    string? TokenPlayerO { get; set; }
    Action Reset { get; set; }
    IRelayCommand? StartGameCommand { get; }
    IRelayCommand? StopGameCommand { get; }
    IRelayCommand? SetupDefaultPlayerCommand { get; }
}