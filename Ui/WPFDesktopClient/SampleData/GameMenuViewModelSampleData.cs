using System;
using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData;

public class GameMenuViewModelSampleData : IGameMenuViewModel
{
    public GameMenuViewModelSampleData()
    {
        // sampleData PlayerX
        NamePlayerX = "PlayerX";
        TokenPlayerX = "X";
        IsAiPlayerX = false;
        IsHumanPlayerX = true;
        IsPlayersTurnPlayerX = true;
        IsWinnerPlayerX = false;
        PointsPlayerX = 25;
        
        // sampleData PlayerO
        NamePlayerO = "PlayerO";
        TokenPlayerO = "O";
        IsAiPlayerO = true;
        IsHumanPlayerO = false;
        IsPlayersTurnPlayerO = false;
        IsWinnerPlayerO = false;
        PointsPlayerO = 34;
    }

    public Action Reset { get; set; } = null!;

    public string NamePlayerX { get; set; }
    public string NamePlayerO { get; set; }
    public string TokenPlayerX { get; set; }
    public string TokenPlayerO { get; set; }
    public bool IsAiPlayerX { get; set; }
    public bool IsAiPlayerO { get; set; }
    public bool IsHumanPlayerX { get; set; }
    public bool IsHumanPlayerO { get; set; }
    public bool IsPlayersTurnPlayerX { get; set; }
    public bool IsPlayersTurnPlayerO { get; set; } 
    public bool IsWinnerPlayerX { get; set; }
    public bool IsWinnerPlayerO { get; set; }
    public int PointsPlayerX { get; set; }
    public int PointsPlayerO { get; set; }
    public IRelayCommand? StartGameCommand { get; set; } = null;
    public IRelayCommand? StopGameCommand { get; set; } = null;
    public IRelayCommand? NewGameCommand { get; set; } = null;
    public IAsyncRelayCommand? LoadLastGameCommand { get; set; } = null;
}