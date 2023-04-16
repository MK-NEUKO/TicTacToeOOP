using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData
{
    public class GameMenuViewModelSampleData : IGameMenuViewModel
    {
        public GameMenuViewModelSampleData()
        {
            var gameViewModel = new GameViewModelSampleData();
            PlayerX = gameViewModel.PlayingPlayerX;
            PlayerO = gameViewModel.PlayingPlayerO;
        }

        public PlayerViewModelSampleData PlayerX { get; set; }
        public PlayerViewModelSampleData PlayerO { get; set; }
        public Action Reset { get; set; }

        public string? NamePlayerX { get; set; }
        public string? NamePlayerO { get; set; }
        public string? TokenPlayerX { get; set; }
        public string? TokenPlayerO { get; set; }
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
        public IRelayCommand? StartGameCommand { get; set; }
        public IRelayCommand? StopGameCommand { get; set; }
        public IRelayCommand? SetupDefaultPlayerCommand { get; set; }
    }
}