using System.Collections.Generic;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData;

public class PlayerViewModelSampleData : IPlayerViewModel
{
    public string? Name { get; set; }
    public string? Token { get; set; }
    public bool IsHuman { get; set; }
    public bool IsAi { get; set; }
    public bool IsPlayersTurn { get; set; }
    public bool IsWinner { get; set; }
    public int Points { get; set; }
    public PlayerData PlayerData { get; set; }

    public int GiveTokenPosition(List<string> tokenList, int clickedAreaId)
    {
        return 42;
    }

    public void SetPoint()
    {
        Points = 42;
    }
}