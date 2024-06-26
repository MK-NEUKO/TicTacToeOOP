﻿using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using System;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData;

public class GameInfoBoardViewModelSampleData : IGameInfoBoardViewModel
{
    public GameInfoBoardViewModelSampleData()
    {
        PlayingPlayerX = CreatePlayer("X");
        PlayingPlayerO = CreatePlayer("O");
        FirstInfoRowLabel = "Description";
        FirstInfoRowValue = "Value";
    }

    public IPlayerViewModel PlayingPlayerX { get; set; }
    public IPlayerViewModel PlayingPlayerO { get; set; }
    public string FirstInfoRowLabel { get; set; }
    public string FirstInfoRowValue { get; set; }
    public GameInfoBoardData GameInfoBoardData { get; set; } = null!;

    public IPlayerViewModel CreatePlayer(string token)
    {
        if (token == null) throw new ArgumentNullException(nameof(token));
        var player = new PlayerViewModelSampleData
        {
            Token = token,
        };
        player.Name = "Player" + player.Token;
        return player;
    }

    public void SavePlayer()
    {
        throw new NotImplementedException();
    }
}