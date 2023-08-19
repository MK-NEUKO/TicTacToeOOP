using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerGameBoardAreaViewModel : ObservableObject, IPlayerGameBoardAreaViewModel
{
    private bool _currentPlayerIsHuman;

    [ObservableProperty] private bool _isStartNewGameAnimation;

    [ObservableProperty]
    [NotifyCanExecuteChangedFor(nameof(AreaWasClickedCommand))]
    private bool _isInGame;

    public PlayerGameBoardAreaViewModel()
    {
        PlayerGameBoardAreaData = new PlayerGameBoardAreaData();
        WeakReferenceMessenger.Default.Register<CurrentPlayerChangedMessage>(this, (r, m) =>
        {
            _currentPlayerIsHuman = m.Value.IsHuman;
            AreaWasClickedCommand.NotifyCanExecuteChanged();
        });
    }

    public PlayerGameBoardAreaData PlayerGameBoardAreaData { get; }

    public bool IsStartSaveGameAnimation
    {
        get => PlayerGameBoardAreaData.IsStartSaveGameAnimation;
        set
        {
            SetProperty(PlayerGameBoardAreaData.IsStartSaveGameAnimation, value, PlayerGameBoardAreaData,
                (areaData, isStartSaveGameAnimation) => areaData.IsStartSaveGameAnimation = isStartSaveGameAnimation);
            SendPlayerGameBoardAreaPropertyChangedMessage();
        }
    }

    public bool IsOccupied
    {
        get => PlayerGameBoardAreaData.IsOccupied;
        set
        {
            SetProperty(PlayerGameBoardAreaData.IsOccupied, value, PlayerGameBoardAreaData,
                (areaData, isOccupied) => areaData.IsOccupied = isOccupied);
            SendPlayerGameBoardAreaPropertyChangedMessage();
        }
    }
    
    public bool IsWinArea
    {
        get => PlayerGameBoardAreaData.IsWinArea;
        set
        {
            SetProperty(PlayerGameBoardAreaData.IsWinArea, value, PlayerGameBoardAreaData,
                (areaData, isWinArea) => areaData.IsWinArea = isWinArea);
            SendPlayerGameBoardAreaPropertyChangedMessage();
        }
    }

    public int Id
    {
        get => PlayerGameBoardAreaData.Id;
        set
        {
            SetProperty(PlayerGameBoardAreaData.Id, value, PlayerGameBoardAreaData, (areaData, id) => areaData.Id = id);
            SendPlayerGameBoardAreaPropertyChangedMessage();
        }
    }

    public string Token 
    {
        get => PlayerGameBoardAreaData.Token;
        set
        {
            SetProperty(PlayerGameBoardAreaData.Token, value, PlayerGameBoardAreaData,
                (areaData, token) => areaData.Token = token);
            SendPlayerGameBoardAreaPropertyChangedMessage();
        }
    }

    private int CounterMouseEnter
    {
        get => PlayerGameBoardAreaData.CounterMouseEnter;
        set
        {
            SetProperty(PlayerGameBoardAreaData.CounterMouseEnter, value, PlayerGameBoardAreaData,
                (areaData, counterMouseEnter) => areaData.CounterMouseEnter = counterMouseEnter);
            SendPlayerGameBoardAreaPropertyChangedMessage();
        }
    }

    public bool CanShowIsOccupied
    {
        get => PlayerGameBoardAreaData.CanShowIsOccupied;
        set
        {
            if (IsOccupied && CounterMouseEnter >= 1)
            {
                SetProperty(PlayerGameBoardAreaData.CanShowIsOccupied, value, PlayerGameBoardAreaData, (areaData, canShowIsOccupied) => areaData.CanShowIsOccupied = canShowIsOccupied);
                SendPlayerGameBoardAreaPropertyChangedMessage();
                MouseEnterForShowIsOccupiedCommand.NotifyCanExecuteChanged();
            }
        }
    }

    [RelayCommand(CanExecute = nameof(CanMouseEnterForShowIsOccupied))]
    private void MouseEnterForShowIsOccupied()
    {
        if (IsOccupied)
        {
            CounterMouseEnter++;
            CanShowIsOccupied = true;
        }
    }

    private bool CanMouseEnterForShowIsOccupied()
    {
        var mouseEnterAfterPlaceAToken = CounterMouseEnter <= 1;
        return mouseEnterAfterPlaceAToken;
    }

    [RelayCommand(CanExecute = nameof(CanAreaWasClicked))]
    private void AreaWasClicked()
    {
        WeakReferenceMessenger.Default.Send(new GameBoardAreaWasClickedMessage(this.Id));
    }

    private bool CanAreaWasClicked()
    {
        var isInGameAndIsHuman = IsInGame && _currentPlayerIsHuman;
        return isInGameAndIsHuman;
    }

    public void ResetToContinue() => InnerReset();

    public void ResetForNewGame()
    {
        InnerReset();
        IsInGame = false;
        IsStartNewGameAnimation = false;
        IsStartSaveGameAnimation = false;
    }

    private void InnerReset()
    {
        Token = string.Empty;
        IsWinArea = false;
        CanShowIsOccupied = false;
        IsOccupied = false;
        CounterMouseEnter = 0;
    }

    private void SendPlayerGameBoardAreaPropertyChangedMessage() => WeakReferenceMessenger.Default.Send(new PlayerGameBoardAreaPropertyChangedMessage(this));
}