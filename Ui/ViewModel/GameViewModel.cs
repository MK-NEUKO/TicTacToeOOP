using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GameViewModel : ObservableObject, IGameViewModel
{
    [ObservableProperty] private IPlayerViewModel _playerX;
    [ObservableProperty] private IPlayerViewModel _playerO;

    public GameViewModel(IPlayerFactory playerFactory)
    {
        if (playerFactory == null) throw new ArgumentNullException(nameof(playerFactory));
        _playerX = playerFactory.CreatePlayer("X");
        _playerO = playerFactory.CreatePlayer("O");
        WeakReferenceMessenger.Default.Register<StartGameMessage>(this, StartGameMessageHandler);
        WeakReferenceMessenger.Default.Register<GetCurrentPlayerRequestMessage>(this, CurrentPlayerRequestHandler);
    }

    private void CurrentPlayerRequestHandler(object recipient, GetCurrentPlayerRequestMessage message)
    {
        if (_playerX.IsPlayersTurn)
        {
            message.Reply(_playerX);
        }

        if (_playerO.IsPlayersTurn)
        {
            message.Reply(_playerO);
        }
        
    }

    private void StartGameMessageHandler(object recipient, StartGameMessage message)
    {
        PlayerX = message.Value.Find(player => player.Token == "X") ?? throw new InvalidOperationException(nameof(StartGameMessageHandler));
        PlayerO = message.Value.Find(player => player.Token == "O") ?? throw new InvalidOperationException(nameof(StartGameMessageHandler));
    }
}