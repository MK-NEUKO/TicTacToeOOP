using CommunityToolkit.Mvvm.ComponentModel;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Helper;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerViewModel : ObservableValidator, IPlayerViewModel
{
    [ObservableProperty] private bool _isAi;

    [ObservableProperty] private bool _isHuman;

    [ObservableProperty] private bool _isPlayersTurn;

    [ObservableProperty] private bool _isWinner;

    [ObservableProperty] private string? _name;

    [ObservableProperty] private int _points;

    [ObservableProperty] private string? _token;


    public PlayerViewModel(string token)
    {
        _token = token ?? throw new ArgumentNullException(nameof(token));
        _name = "Player" + _token;
    }

    public string PlaceAToken()
    {
        return Token;
    }
}