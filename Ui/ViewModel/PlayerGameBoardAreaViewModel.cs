using System.Data;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerGameBoardAreaViewModel : ObservableObject, IPlayerGameBoardAreaViewModel
{
    [ObservableProperty]
    private int _id;

    [ObservableProperty]
    private string? _token;

    [ObservableProperty]
    private bool _isWinArea;

    [ObservableProperty]
    private bool _isStartNewGameAnimation;

    [ObservableProperty]
    private bool _isStartSaveGameAnimation;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(PlaceATokenCommand))]
    private bool _isInGame;
        
    public PlayerGameBoardAreaViewModel(int id)
    {
        _id = id;
        _token = string.Empty;
    }

    [RelayCommand(CanExecute = nameof(CanPlaceAToken))]
    private void PlaceAToken()
    {
        var currentPlayer = WeakReferenceMessenger.Default.Send<GetCurrentPlayerRequestMessage>().Response;
        Token = currentPlayer.PlaceAToken();
    }

    private bool CanPlaceAToken()
    {
        return IsInGame;
    }
}