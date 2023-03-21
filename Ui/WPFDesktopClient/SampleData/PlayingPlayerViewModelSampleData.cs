using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using System;
using MichaelKoch.TicTacToe.Ui.ViewModel;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData;

public class PlayingPlayerViewModelSampleData : IPlayingPlayerViewModel
{
    public PlayingPlayerViewModelSampleData()
    {
        PlayingPlayerX = CreatePlayer("X");
        PlayingPlayerO = CreatePlayer("O");
    }

    public IPlayerViewModel PlayingPlayerX { get; set; }
    public IPlayerViewModel PlayingPlayerO { get; set; }

    private IPlayerViewModel CreatePlayer(string token)
    {
        if (token == null) throw new ArgumentNullException(nameof(token));
        var player = new PlayerViewModelSampleData
        {
            Token = token
        };
        player.Name = "Player" + player.Token;
        return player;
    }
}