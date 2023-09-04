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

    public PlayerViewModel(IMinimaxAlgorithm ai)
    {
        PlayerData = new PlayerData();
        _ai = ai;
        WeakReferenceMessenger.Default.Register<ContinueGameMessage>(this, (r, m) =>
        {
            IsWinner = false;
        });
    }

    private void SendPlayerPropertyChangedMessage()
    {
        WeakReferenceMessenger.Default.Send(new PlayerPropertyChangedMessage(this));
    }

    public PlayerData PlayerData { get; set; }

    public string Name
    {
        get => PlayerData.Name;
        set
        {
            SetProperty(PlayerData.Name, value, PlayerData, (playerData, name) => playerData.Name = name);
            SendPlayerPropertyChangedMessage();
        }
    }

    public string Token
    {
        get => PlayerData.Token;
        set
        {
            SetProperty(PlayerData.Token, value, PlayerData, (playerDate, token) => playerDate.Token = token);
            SendPlayerPropertyChangedMessage();
        }
    }

    public bool IsAi
    {
        get => PlayerData.IsAi;
        set
        {
            SetProperty(PlayerData.IsAi, value, PlayerData, (playerData, isAi) => playerData.IsAi = isAi);
            SetProperty(PlayerData.IsHuman, !value, PlayerData, (playerData, isHuman) => playerData.IsHuman = isHuman);
        }
    }

    public bool IsHuman
    {
        get => PlayerData.IsHuman;
        set
        {
            SetProperty(PlayerData.IsHuman, value, PlayerData, (playerData, isHuman) => playerData.IsHuman = isHuman);
            SetProperty(PlayerData.IsAi, !value, PlayerData, (playerData, isAi) => playerData.IsAi = isAi);
        }
    }

    public bool IsPlayersTurn
    {
        get => PlayerData.IsPlayersTurn;
        set
        {
            if (SetProperty(PlayerData.IsPlayersTurn, value, PlayerData, (playerData, isPlayersTurn) => playerData.IsPlayersTurn = isPlayersTurn)  && value)
            {
                WeakReferenceMessenger.Default.Send(new CurrentPlayerChangedMessage(this));
            }
        }
    }

    public bool IsWinner
    {
        get => PlayerData.IsWinner;
        set
        {
            SetProperty(PlayerData.IsWinner, value, PlayerData, (playerData, isWinner) => playerData.IsWinner = isWinner);
        }
    }

    public int Points
    {
        get => PlayerData.Points;
        set
        {
            SetProperty(PlayerData.Points, value, PlayerData, (playerData, points) => playerData.Points = points);
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