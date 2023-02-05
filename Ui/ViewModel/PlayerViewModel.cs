using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Helper;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerViewModel : ObservableValidator, IPlayerViewModel
{
    private bool _isAi;

    private bool _isHuman;

    private bool _isPlayersTurn;

    [ObservableProperty] private bool _isWinner;

    [ObservableProperty] private string? _name;

    [ObservableProperty] private int _points;

    [ObservableProperty] private string? _token;


    public PlayerViewModel(string token)
    {
        _token = token ?? throw new ArgumentNullException(nameof(token));
        _name = "Player" + _token;
    }

    public bool IsAi
    {
        get => _isAi;
        set
        {
            SetProperty(ref _isAi, value);
            SetProperty(ref _isHuman, !value);
        }
    }

    public bool IsHuman
    {
        get => _isHuman;
        set
        {
            SetProperty(ref _isHuman, value);
            SetProperty(ref _isAi, !value);
        }
    }

    public bool IsPlayersTurn
    {
        get => _isPlayersTurn;
        set
        {
            var isSetTrue = SetProperty(ref _isPlayersTurn, value)  && value;
            if (isSetTrue)
            {
                WeakReferenceMessenger.Default.Send(new CurrentPlayerChangedMessage(this));
            }
        }
    }

    public string PlaceAToken()
    {
        return Token;
    }
}