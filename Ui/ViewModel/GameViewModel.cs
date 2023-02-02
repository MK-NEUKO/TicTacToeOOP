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

    public GameViewModel(IPlayerFactory playerFactory, IPlayerGameBoardViewModel playerGameBoard)
    {
        if (playerFactory == null) throw new ArgumentNullException(nameof(playerFactory));
        _playerGameBoard = playerGameBoard ?? throw new ArgumentNullException(nameof(playerGameBoard));
        _playingPlayerX = playerFactory.CreatePlayer("X");
        _playingPlayerO = playerFactory.CreatePlayer("O");
        WeakReferenceMessenger.Default.Register<StartGameMessage>(this, StartGameMessageHandler);
        WeakReferenceMessenger.Default.Register<GetCurrentPlayerRequestMessage>(this, CurrentPlayerRequestHandler);
        WeakReferenceMessenger.Default.Register<GameBoardStartAnimationCompletedMessage>(this, GameBoardStartAnimationCompletedHandler);
    }

    private void MakeAMove()
    {
        _playerGameBoard.Areas[5].Token = "X";
        _playerGameBoard.Areas[4].Token = "O";

    }

    private void GameBoardStartAnimationCompletedHandler(object recipient, GameBoardStartAnimationCompletedMessage message)
    {
        MakeAMove();
    }

    private void CurrentPlayerRequestHandler(object recipient, GetCurrentPlayerRequestMessage message)
    {
        if (PlayingPlayerX.IsPlayersTurn)
        {
            message.Reply(PlayingPlayerX);
        }

        if (PlayingPlayerO.IsPlayersTurn)
        {
            message.Reply(PlayingPlayerO);
        }
    }

    private void StartGameMessageHandler(object recipient, StartGameMessage message)
    {
        PlayingPlayerX = message.Value.Find(player => player.Token == "X") ?? throw new InvalidOperationException(nameof(StartGameMessageHandler));
        PlayingPlayerO = message.Value.Find(player => player.Token == "O") ?? throw new InvalidOperationException(nameof(StartGameMessageHandler));
        _playerGameBoard.Areas.ForEach((area) => area.IsStartNewGameAnimation = true);
    }
}