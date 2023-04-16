using System.ComponentModel;
using System.Data;
using System.Xml.XPath;
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
    private IPlayerViewModel _currentPlayer;

    public GameViewModel(IViewModelFactory<IGameOverDialogViewModel> gameOverDialogViewModelFactory,
        IWindowService<IGameOverDialogViewModel> gameOverDialogService,
                         IPlayerGameBoardViewModel playerGameBoard,
                         IPlayingPlayerViewModel playingPlayer,
                         IGameEvaluator gameEvaluator)
    {
        _gameOverDialogViewModelFactory = gameOverDialogViewModelFactory ?? throw new ArgumentNullException(nameof(gameOverDialogViewModelFactory));
        _gameOverDialogService = gameOverDialogService ?? throw new ArgumentNullException(nameof(gameOverDialogService));
        _playerGameBoard = playerGameBoard ?? throw new ArgumentNullException(nameof(playerGameBoard));
        _playingPlayer = playingPlayer ?? throw new ArgumentNullException(nameof(playingPlayer));
        _gameEvaluator = gameEvaluator ?? throw new ArgumentNullException(nameof(gameEvaluator));
        _currentPlayer = playingPlayer.CreatePlayer("X");
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

    private async Task MakeAMoveAsync(int clickedAreaId = -1)
    {
        do
        {
            if (_currentPlayer.Token == null) return;
            var areaId = await _currentPlayer.GiveTokenPositionTaskAsync(_playerGameBoard.GetCurrentTokenList(), clickedAreaId);
            if(areaId == -1) return;
            if(await _playerGameBoard.TrySetTokenTaskAsync(_currentPlayer.Token, _currentPlayer.IsHuman, areaId)) return;

            var evaluationResult = await _gameEvaluator.EvaluateGameTaskAsync(_playerGameBoard.GetCurrentTokenList(), _currentPlayer.Token);
            if (evaluationResult.IsWinner)
            {
                ShowWinner(evaluationResult);
                if (GetPlayerDecisionIsStartNewGame(evaluationResult)) return;
            }

            if (evaluationResult.IsDraw)
            {
                if(GetPlayerDecisionIsStartNewGame(evaluationResult)) return;
            }

            ChangeCurrentPlayer();

        } while (_currentPlayer.IsAi);
    }

    private bool GetPlayerDecisionIsStartNewGame(IEvaluationResult evaluationResult)
    {
        var dialogResult = false;
        var gameOverViewModel = _gameOverDialogViewModelFactory.Create();
        if (evaluationResult.IsWinner)
        {
            gameOverViewModel.Message = $"{_currentPlayer.Name} is the winner and gets a Point";
        }

        if (evaluationResult.IsDraw)
        {
            gameOverViewModel.Message =
                "The game is a draw, no one gets a point. The draw games are counted under the player display.";
        }
        _gameOverDialogService.ShowDialog(gameOverViewModel);
        dialogResult = gameOverViewModel.IsSelectNewGame;

        return dialogResult;
    }

    private void ShowWinner(IEvaluationResult evaluationResult)
    {
        _playerGameBoard.AnimateWinAreas(evaluationResult.WinAreas);
        _currentPlayer.IsWinner = evaluationResult.IsWinner;
        _currentPlayer.SetPoint();
    }

    private void ChangeCurrentPlayer()
    {
        _playingPlayer.PlayingPlayerX.IsPlayersTurn = !_playingPlayer.PlayingPlayerX.IsPlayersTurn;
        _playingPlayer.PlayingPlayerO.IsPlayersTurn = !_playingPlayer.PlayingPlayerO.IsPlayersTurn;
    }
}