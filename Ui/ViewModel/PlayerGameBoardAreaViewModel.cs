using System.Data;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerGameBoardAreaViewModel : ObservableObject, IPlayerGameBoardAreaViewModel
{
    private int _counterMouseEnter;
    private bool _canShowIsOccupied;
    private IPlayerViewModel? _currentPlayer;

    [ObservableProperty] private int _id;
    [ObservableProperty] private string? _token;
    [ObservableProperty] private bool _isWinArea;
    [ObservableProperty] private bool _isStartNewGameAnimation;
    [ObservableProperty] private bool _isStartSaveGameAnimation;
    [ObservableProperty] private bool _isOccupied;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AreaWasClickedCommand))]
    private bool _isInGame;

    public PlayerGameBoardAreaViewModel()
    {
        _token = string.Empty;
        WeakReferenceMessenger.Default.Register<CurrentPlayerChangedMessage>(this, (r, m) =>
        {
            _currentPlayer = m.Value ?? throw new ArgumentNullException(nameof(_currentPlayer));
            AreaWasClickedCommand.NotifyCanExecuteChanged();
        });
    }

    public bool CanShowIsOccupied
    {
        get => _canShowIsOccupied;
        set
        {
            if (IsOccupied && _counterMouseEnter >= 1)
            {
                SetProperty(ref _canShowIsOccupied, value);
                MouseEnterForShowIsOccupiedCommand.NotifyCanExecuteChanged();
            }
        }
    }

    [RelayCommand(CanExecute = nameof(CanMouseEnterForShowIsOccupied))]
    private void MouseEnterForShowIsOccupied()
    {
        if (IsOccupied)
        {
            _counterMouseEnter++;
            CanShowIsOccupied = true;
        }
    }

    private bool CanMouseEnterForShowIsOccupied()
    {
        var mouseEnterAfterPlaceAToken = _counterMouseEnter <= 1;
        return mouseEnterAfterPlaceAToken;
    }

    [RelayCommand(CanExecute = nameof(CanAreaWasClicked))]
    private void AreaWasClicked()
    {
        WeakReferenceMessenger.Default.Send(new GameBoardAreaWasClickedMessage(this.Id));
    }

    private bool CanAreaWasClicked()
    {
        var isInGameAndIsHuman = IsInGame && _currentPlayer.IsHuman;
        return isInGameAndIsHuman;
    }

    public void ResetToContinue()
    {
        Token = string.Empty;
        IsWinArea = false;
        CanShowIsOccupied = false;
        IsOccupied = false;
        _counterMouseEnter = 0;
    }
}