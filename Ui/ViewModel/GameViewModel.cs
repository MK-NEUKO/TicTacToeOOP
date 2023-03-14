using System.ComponentModel;
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
    [ObservableProperty] private IPlayerViewModel _playingPlayerX;
    [ObservableProperty] private IPlayerViewModel _playingPlayerO;
    private readonly IViewModelFactory<IGameOverDialogViewModel> _gameOverFactory;
    private readonly IViewModelFactory<IPlayerViewModel> _playerFactory;
    private readonly IPlayerGameBoardViewModel _playerGameBoard;
    private readonly IGameEvaluator _gameEvaluator;
    private IPlayerViewModel _currentPlayer;
    private readonly IWindowService _dialogService;
    private bool _isDraw;
    private bool _isGameOver;

    public GameViewModel(IViewModelFactory<IGameOverDialogViewModel> gameOverFactory,
                         IViewModelFactory<IPlayerViewModel> playerFactory, 
                         IPlayerGameBoardViewModel playerGameBoard, 
                         IGameEvaluator gameEvaluator,
                         IWindowService dialogService)
    {
        _gameOverFactory = gameOverFactory ?? throw new ArgumentNullException(nameof(gameOverFactory));
        _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
        _playerGameBoard = playerGameBoard ?? throw new ArgumentNullException(nameof(playerGameBoard));
        _gameEvaluator = gameEvaluator ?? throw new ArgumentNullException(nameof(gameEvaluator));
        _dialogService = dialogService ?? throw new ArgumentNullException(nameof(dialogService));
        _playingPlayerX = CreatePlayer("X");
        _playingPlayerO = CreatePlayer("O");
        _currentPlayer = CreatePlayer("X");
        WeakReferenceMessenger.Default.Register<StartGameButtonClickedMessage>(this, StartGameButtonClickedMessageHandler);
        WeakReferenceMessenger.Default.Register<GameBoardAreaWasClickedMessage>(this, GameBoardAreaWasClickedHandler);
        WeakReferenceMessenger.Default.Register<GameBoardStartAnimationCompletedMessage>(this, GameBoardStartAnimationCompletedHandler);
        WeakReferenceMessenger.Default.Register<CurrentPlayerChangedMessage>(this, CurrentPlayerChangedMessageHandler);
    }

    private IPlayerViewModel CreatePlayer(string token)
    {
        if (token == null) throw new ArgumentNullException(nameof(token));
        var player = _playerFactory.Create();
        player.Token = token;
        player.Name = "Player" + player.Token;
        return player;
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
        PlayingPlayerX = buttonClickedMessage.Value.Find(x => x.Token == "X") ?? throw new InvalidOperationException(nameof(StartGameButtonClickedMessageHandler));
        PlayingPlayerO = buttonClickedMessage.Value.Find(x => x.Token == "O") ?? throw new InvalidOperationException(nameof(StartGameButtonClickedMessageHandler));
        _playerGameBoard.StartGameStartAnimation();
    }

    private async Task MakeAMoveAsync(int clickedAreaId = 10)
    {
        var counter = 0;
        do
        {
            var areaId = await _currentPlayer.GiveTokenPositionTaskAsync(_playerGameBoard.GetCurrentTokenList(), clickedAreaId);
            if(areaId == -1) return;
            if(await _playerGameBoard.TrySetTokenTaskAsync(_currentPlayer.Token!, _currentPlayer.IsHuman, areaId)) return;

            var evaluationResult = await _gameEvaluator.EvaluateGameTaskAsync(_playerGameBoard.GetCurrentTokenList(), _currentPlayer.Token!);
            if (evaluationResult.IsWinner)
            {
                ShowWinner(evaluationResult);
                return;
            }

            if (evaluationResult.IsDraw)
            {
                ShowDraw();
                return;
            }

            await ChangeCurrentPlayerAsync();
            counter++;

        } while (_currentPlayer.IsAi && counter < 9);
    }

    private void ShowWinner(IEvaluationResult evaluationResult)
    {
        _playerGameBoard.AnimateWinAreas(evaluationResult.WinAreas);
        _currentPlayer.IsWinner = evaluationResult.IsWinner;
        _currentPlayer.SetPoint();
        var gameOverViewModel = _gameOverFactory.Create();
        gameOverViewModel.Message = "Test Test";
        _dialogService.ShowDialog(gameOverViewModel);
        return;
    }

    private void ShowDraw()
    {
        _currentPlayer.Points = 25;
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