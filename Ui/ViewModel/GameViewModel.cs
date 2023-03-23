﻿using System.ComponentModel;
using System.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Factories;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GameViewModel : ObservableObject, IGameViewModel
{
    private readonly IViewModelFactory<IGameOverDialogViewModel> _gameOverDialogViewModelFactory;
    private readonly IWindowService<IGameOverDialogViewModel> _gameOverDialogService;
    private readonly IPlayerGameBoardViewModel _playerGameBoard;
    private readonly IPlayingPlayerViewModel _playingPlayer;
    private readonly IGameEvaluator _gameEvaluator;
    private IPlayerViewModel? _currentPlayer;

    public GameViewModel(IViewModelFactory<IGameOverDialogViewModel> gameOverDialogViewModelFactory,
                         IWindowService<IGameOverDialogViewModel> gameOverDialogService,
                         IPlayerGameBoardViewModel playerGameBoard,
                         IPlayingPlayerViewModel playingPlayer,
                         IGameEvaluator gameEvaluator)
    {
        _gameOverDialogViewModelFactory = gameOverDialogViewModelFactory ?? throw new ArgumentNullException(nameof(gameOverDialogViewModelFactory));
        _gameOverDialogService = gameOverDialogService ?? throw new ArgumentNullException(nameof(gameOverDialogService));
        _playerGameBoard = playerGameBoard ?? throw new ArgumentNullException(nameof(playerGameBoard));
        _playingPlayer = playingPlayer;
        _gameEvaluator = gameEvaluator ?? throw new ArgumentNullException(nameof(gameEvaluator));
        WeakReferenceMessenger.Default.Register<StartGameButtonClickedMessage>(this, (r, m) =>
        {
            _playerGameBoard.StartGameStartAnimation();
        });
        WeakReferenceMessenger.Default.Register<GameBoardAreaWasClickedMessage>(this, (GameBoardAreaWasClickedHandler));
        WeakReferenceMessenger.Default.Register<GameBoardStartAnimationCompletedMessage>(this, GameBoardStartAnimationCompletedHandler);
        WeakReferenceMessenger.Default.Register<CurrentPlayerChangedMessage>(this, (r, m) =>
        {
            _currentPlayer = m.Value;
        });
    }

    private async void GameBoardStartAnimationCompletedHandler(object recipient, GameBoardStartAnimationCompletedMessage message)
    {
        await MakeAMoveAsync();
    }

    private async void GameBoardAreaWasClickedHandler(object recipient, GameBoardAreaWasClickedMessage message)
    {
        var clickedAreaId = message.Value;
        await MakeAMoveAsync(clickedAreaId);
    }

    private async Task MakeAMoveAsync(int clickedAreaId = 10)
    {
        do
        {
            if(_currentPlayer is null) return;
            var areaId = await _currentPlayer.GiveTokenPositionTaskAsync(_playerGameBoard.GetCurrentTokenList(), clickedAreaId);
            if(areaId == -1) return;
            if(_currentPlayer.Token is  null) return;
            if(await _playerGameBoard.TrySetTokenTaskAsync(_currentPlayer.Token, _currentPlayer.IsHuman, areaId)) return;

            var evaluationResult = await _gameEvaluator.EvaluateGameTaskAsync(_playerGameBoard.GetCurrentTokenList(), _currentPlayer.Token);
            if (evaluationResult.IsWinner)
            {
                ShowWinner(evaluationResult);
                //if(_currentPlayer.IsHuman) return;
            }

            if (evaluationResult.IsDraw)
            {
                ShowDraw();
                return;
            }

            ChangeCurrentPlayer();

        } while (_currentPlayer.IsAi);
    }

    private void ShowWinner(IEvaluationResult evaluationResult)
    {
        _playerGameBoard.AnimateWinAreas(evaluationResult.WinAreas);
        _currentPlayer.IsWinner = evaluationResult.IsWinner;
        _currentPlayer.SetPoint();
        var gameOverViewModel = _gameOverDialogViewModelFactory.Create();
        gameOverViewModel.Message = $"{_currentPlayer.Name} is the winner and gets a Point";
        _gameOverDialogService.ShowDialog(gameOverViewModel);
    }

    private void ShowDraw()
    {
        var gameOverViewModel = _gameOverDialogViewModelFactory.Create();
        gameOverViewModel.Message =
            "The game is a draw, no one gets a point. The draw games are counted under the player display.";
        _gameOverDialogService.ShowDialog(gameOverViewModel);
    }

    private void ChangeCurrentPlayer()
    {
        _playingPlayer.PlayingPlayerX.IsPlayersTurn = !_playingPlayer.PlayingPlayerX.IsPlayersTurn;
        _playingPlayer.PlayingPlayerO.IsPlayersTurn = !_playingPlayer.PlayingPlayerO.IsPlayersTurn;
    }
}