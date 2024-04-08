﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.ViewModel;

public partial class GameInfoBoardViewModel : ObservableObject, IGameInfoBoardViewModel
{
    private readonly IPlayerService _playerService;

    public GameInfoBoardViewModel(IPlayer player, IPlayer opponent, IPlayerService playerService)
    {
        Player = player;
        Player.Token = "X";
        Player.IsCurrentPlayer = true;
        Opponent = opponent;
        Opponent.Token = "O";
        Opponent.IsCurrentPlayer = false;
        _playerService = playerService;
    }

    [RelayCommand]
    private void Test()
    {
        Player.Name = "Test";
        
    }

    [RelayCommand]
    private async Task Test2()
    {
        await _playerService.ChangeIsOnTheMove(Player, Opponent);
    }

    public IPlayer Player { get; }
    public IPlayer Opponent { get; }
    public List<string> InfoRowLabels { get; set; } = new List<string> { "Row-desc. 1", "Row-desc. 2" };
    public List<string> InfoRowValues { get; set; } = new List<string> { "Row-Va. 1", "Row-Va.2" };
}