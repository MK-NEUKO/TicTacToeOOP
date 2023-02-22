using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GameViewModel : ObservableObject, IGameViewModel
{
    [ObservableProperty] private IPlayerViewModel _playingPlayerX;
    [ObservableProperty] private IPlayerViewModel _playingPlayerO;
    private readonly IPlayerGameBoardViewModel _playerGameBoard;
    private readonly IGameEvaluator _gameEvaluator;
    private IPlayerViewModel _currentPlayer;
    private bool _isDraw;
    private bool _isGameOver;

    public GameViewModel(IPlayerFactory playerFactory, IPlayerGameBoardViewModel playerGameBoard, IGameEvaluator gameEvaluator)
    {
        if (playerFactory == null) throw new ArgumentNullException(nameof(playerFactory));
        _playerGameBoard = playerGameBoard ?? throw new ArgumentNullException(nameof(playerGameBoard));
        _gameEvaluator = gameEvaluator ?? throw new ArgumentNullException(nameof(gameEvaluator));
        _playingPlayerX = playerFactory.CreatePlayer("X");
        _playingPlayerO = playerFactory.CreatePlayer("O");
        _currentPlayer = playerFactory.CreatePlayer("X");
        WeakReferenceMessenger.Default.Register<StartGameButtonClickedMessage>(this, StartGameButtonClickedMessageHandler);
        WeakReferenceMessenger.Default.Register<GameBoardAreaWasClickedMessage>(this, GameBoardAreaWasClickedHandler);
        WeakReferenceMessenger.Default.Register<GameBoardStartAnimationCompletedMessage>(this, GameBoardStartAnimationCompletedHandler);
        WeakReferenceMessenger.Default.Register<CurrentPlayerChangedMessage>(this, CurrentPlayerChangedMessageHandler);
    }

    private void CurrentPlayerChangedMessageHandler(object recipient, CurrentPlayerChangedMessage message)
    {
        _currentPlayer = message.Value;
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

    private void StartGameButtonClickedMessageHandler(object recipient, StartGameButtonClickedMessage buttonClickedMessage)
    {
        PlayingPlayerX = buttonClickedMessage.Value.Find(player => player.Token == "X") ?? throw new InvalidOperationException(nameof(StartGameButtonClickedMessageHandler));
        PlayingPlayerO = buttonClickedMessage.Value.Find(player => player.Token == "O") ?? throw new InvalidOperationException(nameof(StartGameButtonClickedMessageHandler));
        _playerGameBoard.StartGameStartAnimation();
    }

    private async Task MakeAMoveAsync(int clickedAreaId = 10)
    {
        var counter = 0;
        do
        {
            var areaId = await _currentPlayer.GiveTokenPositionTaskAsync(_playerGameBoard.GetCurrentTokenList(), clickedAreaId);
            if(areaId == -1) return;
            if(await _playerGameBoard.TrySetTokenTaskAsync(_currentPlayer.Token, _currentPlayer.IsHuman, areaId)) return;

            
            var evaluationResult = await _gameEvaluator.EvaluateGameTaskAsync(_playerGameBoard.GetCurrentTokenList(), _currentPlayer.Token);
            if (evaluationResult.IsWinner)
            {
                _playerGameBoard.AnimateWinAreas(evaluationResult.WinAreas);
                _currentPlayer.IsWinner = evaluationResult.IsWinner;
                _currentPlayer.SetPoint();
                return;
            }

            if (evaluationResult.IsDraw)
            {
                _currentPlayer.Points = 25;
                return;
            }
            await ChangeCurrentPlayerAsync();
            counter++;

        } while (_currentPlayer.IsAi && counter < 9);
    }

    private async Task ChangeCurrentPlayerAsync()
    {
        await Task.Run(() =>
        {
            PlayingPlayerX.IsPlayersTurn = !PlayingPlayerX.IsPlayersTurn;
            PlayingPlayerO.IsPlayersTurn = !PlayingPlayerO.IsPlayersTurn;
        });
    }
}