using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerViewModel : ObservableValidator, IPlayerViewModel
{
    private readonly IMinimaxAlgorithm _ai;
    private bool _isAi;
    private bool _isHuman;
    private bool _isPlayersTurn;
    [ObservableProperty] private bool _isWinner;
    [ObservableProperty] private int _points;
    [ObservableProperty] private string _token;

    public PlayerViewModel(IMinimaxAlgorithm ai)
    {
        PlayerData = new PlayerData();
        _ai = ai;
        _token = string.Empty;
        WeakReferenceMessenger.Default.Register<ContinueGameMessage>(this, (r, m) =>
        {
            IsWinner = false;
        });
    }

    public PlayerData PlayerData { get; }

    public string Name
    {
        get => PlayerData.Name;
        set
        {
            SetProperty(PlayerData.Name, value, PlayerData, (playerData, name) => playerData.Name = name);
            WeakReferenceMessenger.Default.Send(new PlayerPropertyChangedMessage(this));
        }
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

    public int GiveTokenPosition(List<string> tokenList, int clickedAreaId)
    {
        if (tokenList == null) throw new ArgumentNullException(nameof(tokenList));
        if (this.IsAi)
        {
            var area = -1;
            area = _ai.FindBestMove(tokenList, Token);
            return area;
        }

        if (this.IsHuman)
            return clickedAreaId;
        return -1;
    }

    public void SetPoint()
    {
        if (this.IsWinner) this.Points++;
    }
}