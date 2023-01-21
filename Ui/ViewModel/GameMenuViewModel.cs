using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GameMenuViewModel : ObservableObject, IGameMenuViewModel 
{
    public GameMenuViewModel(IPlayerFactory playerFactory)
    {
        if (playerFactory == null) throw new ArgumentNullException(nameof(playerFactory));
        _playerX = playerFactory.CreatePlayer("X");
        _playerO = playerFactory.CreatePlayer("O");
    }

    [ObservableProperty] private IPlayerViewModel _playerX;
    [ObservableProperty] private IPlayerViewModel _playerO;

    [RelayCommand]
    private void StartGame()
    {
        var playerList = new List<IPlayerViewModel>
        {
            PlayerX,
            PlayerO
        };
        WeakReferenceMessenger.Default.Send(new StartGameMessage(playerList));
    }

    [RelayCommand]
    private void SetupDefaultPlayer()
    {
        _playerX.Name = "PlayerX";
        _playerX.IsHuman = true;
        _playerX.IsPlayersTurn = true;
        _playerO.Name = "PlayerO";
        _playerO.IsAi = true;
    }
}