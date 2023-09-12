using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;
using MichaelKoch.TicTacToe.Ui.ViewModel.Factories;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

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

        WeakReferenceMessenger.Default.Register<StartGameMessage>(this, (r, m) =>
        {
            IsInGame = true;
            _playerGameBoard.StartGameStartAnimation(m.Value.IsNewGame);
        });
        WeakReferenceMessenger.Default.Register<StartNewGameMessage>(this, (r, m) =>
        {
            IsInGame = false;
            _numberOfDraw = 0;
        });
        WeakReferenceMessenger.Default.Register<GameBoardAreaWasClickedMessage>(this, async (r, m) =>
        {
            var clickedAreaId = m.Value;
            await MakeAMoveAsync(clickedAreaId);
        });
        WeakReferenceMessenger.Default.Register<GameBoardStartAnimationCompletedMessage>(this, async (r, m) =>
        {
            await MakeAMoveAsync();
        }); 
        WeakReferenceMessenger.Default.Register<CurrentPlayerChangedMessage>(this, (r, m) =>
        {
            _currentPlayer = m.Value;
        });
        WeakReferenceMessenger.Default.Register<PauseGameMessage>(this, async (r, m) =>
        {
            IsInGame = !(m.Value);
            if (IsInGame)
            {
                await MakeAMoveAsync();
            }
        });
    }

    public bool IsInGame { get; private set; }

    private async Task MakeAMoveAsync(int clickedAreaId = -1)
    {
        do
        {
            if (!IsInGame) return;
            if (_currentPlayer.Token == string.Empty) return;
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
        var gameOverDialogViewModel = _gameOverDialogViewModelFactory.Create();
        if (evaluationResult.IsWinner)
        {
            gameOverDialogViewModel.Message = $"{_currentPlayer.Name} is the winner and gets a Point";
        }

        if (evaluationResult.IsDraw)
        {
            gameOverDialogViewModel.Message =
                "The game is a draw, no one gets a point. The draw games are counted under the player display.";
        }
        _gameOverDialogService.ShowDialog(gameOverDialogViewModel);
        var dialogResult = gameOverDialogViewModel.IsSelectNewGame;

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

    public async Task SaveGame()
    {
        await _saveGameManager.SaveCurrentGameAsync(_gameInfoBoard.GameInfoBoardData, _playerGameBoard.PlayerGameBoardData);
    }
}