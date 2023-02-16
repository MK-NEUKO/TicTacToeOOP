﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerGameBoardViewModel : ObservableObject, IPlayerGameBoardViewModel
{
    private int _animationCompletedCounter = 0;
    private List<IPlayerGameBoardAreaViewModel> _areas;

    public PlayerGameBoardViewModel(IGameBoardAreaFactory gameBoardAreaFactory, IGameEvaluator gameEvaluator)
    {
        _areas = gameBoardAreaFactory.CreateAreas();
    }

    public IReadOnlyList<IPlayerGameBoardAreaViewModel> Areas { get => _areas.AsReadOnly(); }

    public List<string> GetCurrentTokenList()
    {
        var currentTokenList = new List<string>();
        _areas.ForEach(a => currentTokenList.Add(a.Token));
        return currentTokenList;
    }

    public void AnimateWinAreas(List<bool> resultWinAreas)
    {
        _areas.ForEach(a => a.IsWinArea = resultWinAreas[a.Id]);
    }

    public void StartGameStartAnimation()
    {
        _areas.ForEach(a => a.IsStartNewGameAnimation = true);
    }

    [RelayCommand]
    public void GameBoardStartAnimationCompleted()
    {
        _animationCompletedCounter++;
        if (_animationCompletedCounter != 9) return;
        _areas.ForEach(area => area.IsInGame = true);
        WeakReferenceMessenger.Default.Send(new GameBoardStartAnimationCompletedMessage(this));
    }

    public async Task<bool> TrySetTokenTaskAsync(string token, int areaId)
    {
        if (token == null) throw new ArgumentNullException(nameof(token));
        if (areaId is < 0 or > 9) throw new ArgumentOutOfRangeException(nameof(areaId));
        if (!string.IsNullOrWhiteSpace(Areas[areaId].Token)) return false;
        await Task.Run(() =>
        {
            var rnd = new Random();
            var sleepTime = rnd.Next(500, 2000);
            Thread.Sleep(sleepTime);
            Areas[areaId].Token = token;
        });
        return true;
    }
}