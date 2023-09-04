using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Factories;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;
using System.Text.Json;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public class GameViewModel: IGameViewModel
{
    private readonly IViewModelFactory<IGameOverDialogViewModel> _gameOverDialogViewModelFactory;
    private readonly IWindowService<IGameOverDialogViewModel> _gameOverDialogService;
    private readonly IPlayerGameBoardViewModel _playerGameBoard;
    private readonly IGameInfoBoardViewModel _gameInfoBoard;
    private readonly IGameEvaluator _gameEvaluator;
    private readonly ISaveGameManager _saveGameManager;
    private IPlayerViewModel _currentPlayer;
    private int _numberOfDraw;

    public GameViewModel(IViewModelFactory<IGameOverDialogViewModel> gameOverDialogViewModelFactory,
                         IWindowService<IGameOverDialogViewModel> gameOverDialogService,
                         IPlayerGameBoardViewModel playerGameBoard,
                         IGameInfoBoardViewModel gameInfoBoard,
                         IGameEvaluator gameEvaluator,
                         ISaveGameManager saveGameManager)
    {
        _gameOverDialogViewModelFactory = gameOverDialogViewModelFactory ?? throw new ArgumentNullException(nameof(gameOverDialogViewModelFactory));
        _gameOverDialogService = gameOverDialogService ?? throw new ArgumentNullException(nameof(gameOverDialogService));
        _playerGameBoard = playerGameBoard ?? throw new ArgumentNullException(nameof(playerGameBoard));
        _gameInfoBoard = gameInfoBoard ?? throw new ArgumentNullException(nameof(gameInfoBoard));
        _gameEvaluator = gameEvaluator ?? throw new ArgumentNullException(nameof(gameEvaluator));
        _saveGameManager = saveGameManager ?? throw new ArgumentNullException(nameof(saveGameManager));
        _currentPlayer = gameInfoBoard.CreatePlayer("X");
        WeakReferenceMessenger.Default.Register<StartGameButtonClickedMessage>(this, (r, m) =>
        {
            IsInGame = true;
            _playerGameBoard.StartGameStartAnimation(m.Value.IsNewGame);
        });
        WeakReferenceMessenger.Default.Register<StartNewGameMessage>(this, (r, m) =>
        {
            _numberOfDraw = 0;
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

    public bool IsInGame { get; private set; }

    private async Task MakeAMoveAsync(int clickedAreaId = -1)
    {
        do
        {
            if (_currentPlayer.Token == null) return;
            var areaId = await Task.Run(() => _currentPlayer.GiveTokenPosition(_playerGameBoard.GetCurrentTokenList(), clickedAreaId));
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
                ShowDraw();
                if(GetPlayerDecisionIsStartNewGame(evaluationResult)) return;
            }

            ChangeCurrentPlayer();

        } while (_currentPlayer.IsAi);
    }

    private void ShowDraw()
    {
        _numberOfDraw++;
        _gameInfoBoard.FirstInfoRowLabel = "Draw games";
        _gameInfoBoard.FirstInfoRowValue = Convert.ToString(_numberOfDraw);
    }

    private bool GetPlayerDecisionIsStartNewGame(IEvaluationResult evaluationResult)
    {
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
        var dialogResult = gameOverViewModel.IsSelectNewGame;

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
        _gameInfoBoard.PlayingPlayerX.IsPlayersTurn = !_gameInfoBoard.PlayingPlayerX.IsPlayersTurn;
        _gameInfoBoard.PlayingPlayerO.IsPlayersTurn = !_gameInfoBoard.PlayingPlayerO.IsPlayersTurn;
    }

    public void SaveGame()
    {
        _saveGameManager.SaveCurrentGame(_gameInfoBoard.GameInfoBoardData, _playerGameBoard.PlayerGameBoardData);
    }
}