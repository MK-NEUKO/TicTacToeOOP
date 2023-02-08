using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GameViewModel : ObservableObject, IGameViewModel
{
    [ObservableProperty] private IPlayerViewModel _playingPlayerX;
    [ObservableProperty] private IPlayerViewModel _playingPlayerO;
    private readonly IPlayerGameBoardViewModel _playerGameBoard;
    private IPlayerViewModel _currentPlayer;
    private bool _isGameDraw;

    public GameViewModel(IPlayerFactory playerFactory, IPlayerGameBoardViewModel playerGameBoard)
    {
        if (playerFactory == null) throw new ArgumentNullException(nameof(playerFactory));
        _playerGameBoard = playerGameBoard ?? throw new ArgumentNullException(nameof(playerGameBoard));
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
        do
        {
            if (!_currentPlayer.TryPlaceAToken(_playerGameBoard, clickedAreaId)) return;
            if (_playerGameBoard.EvaluateGameState(_currentPlayer.Token))
            {

            }
            _currentPlayer.SetPoint();
            ChangeCurrentPlayer();
        } while (_currentPlayer.IsAi);
    }

    private void ChangeCurrentPlayer()
    {
        PlayingPlayerX.IsPlayersTurn = !PlayingPlayerX.IsPlayersTurn;
        PlayingPlayerO.IsPlayersTurn = !PlayingPlayerO.IsPlayersTurn;
    }
}