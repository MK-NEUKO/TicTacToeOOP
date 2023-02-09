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

    private void GameBoardStartAnimationCompletedHandler(object recipient, GameBoardStartAnimationCompletedMessage message)
    {
        MakeAMove();
    }

    private void GameBoardAreaWasClickedHandler(object recipient, GameBoardAreaWasClickedMessage message)
    {
        var clickedAreaId = message.Value;
        MakeAMove(clickedAreaId);
    }

    private void StartGameButtonClickedMessageHandler(object recipient, StartGameButtonClickedMessage buttonClickedMessage)
    {
        PlayingPlayerX = buttonClickedMessage.Value.Find(player => player.Token == "X") ?? throw new InvalidOperationException(nameof(StartGameButtonClickedMessageHandler));
        PlayingPlayerO = buttonClickedMessage.Value.Find(player => player.Token == "O") ?? throw new InvalidOperationException(nameof(StartGameButtonClickedMessageHandler));
        _playerGameBoard.Areas.ForEach((area) => area.IsStartNewGameAnimation = true);
    }

    private void MakeAMove(int clickedAreaId = 10)
    {
        var isGameOver = false;
        do
        {
            if (!_currentPlayer.TryPlaceAToken(_playerGameBoard, clickedAreaId)) return;
            var result = _gameEvaluator.EvaluateGame(_playerGameBoard.GetTokenList(), _currentPlayer.Token);
            if (result.IsWinner)
            {
                _currentPlayer.IsWinner = result.IsWinner;
                _playerGameBoard.AnimateWinAreas(result.WinAreas);
                _currentPlayer.SetPoint();
                isGameOver = true;
            }

            if (result.IsDraw)
            {
                _currentPlayer.Points = 50;
                isGameOver = true;
            }
            ChangeCurrentPlayer();
        } while (_currentPlayer.IsAi && isGameOver);
    }

    private void ChangeCurrentPlayer()
    {
        PlayingPlayerX.IsPlayersTurn = !PlayingPlayerX.IsPlayersTurn;
        PlayingPlayerO.IsPlayersTurn = !PlayingPlayerO.IsPlayersTurn;
    }
}