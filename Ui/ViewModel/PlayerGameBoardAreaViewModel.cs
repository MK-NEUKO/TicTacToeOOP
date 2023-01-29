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
        
    public PlayerGameBoardAreaViewModel(int id)
    {
        _id = id;
        _token = string.Empty;
    }

    [RelayCommand]
    private void PlaceAToken()
    {
        var currentPlayer = WeakReferenceMessenger.Default.Send<GetCurrentPlayerRequestMessage>().Response;
        Token = currentPlayer.PlaceAToken();
    }
}