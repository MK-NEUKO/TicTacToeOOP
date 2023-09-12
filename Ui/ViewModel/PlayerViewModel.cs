using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.ComponentModel;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerViewModel : ObservableValidator, IPlayerViewModel
{
    private readonly IMinimaxAlgorithm _ai;
    private PlayerData _playerData;

    public PlayerViewModel(IMinimaxAlgorithm ai)
    {
        _playerData = new PlayerData();
        _ai = ai;
        WeakReferenceMessenger.Default.Register<ContinueGameMessage>(this, (r, m) =>
        {
            IsWinner = false;
        });
    }

    private void OverridePlayerData()
    {
        WeakReferenceMessenger.Default.Send(new OverridePlayerDataMessage(this));
    }

    public AiDifficultyLevel AiDifficultyLevel
    {
        get => PlayerData.AiDifficultyLevel;
        set
        {
            SetProperty(PlayerData.AiDifficultyLevel, value, PlayerData,
                (playerData, aiDifficultyLevel) => playerData.AiDifficultyLevel = aiDifficultyLevel);
            OverridePlayerData();
        }
    }

    public PlayerData PlayerData
    {
        get => _playerData;
        set
        {
            if (SetProperty(ref _playerData, value))
            {
                IsPlayersTurn = value.IsPlayersTurn;
            }
        }
    }

    public string Name
    {
        get => PlayerData.Name;
        set
        {
            SetProperty(PlayerData.Name, value, PlayerData, 
                (playerData, name) => playerData.Name = name);
            OverridePlayerData();
        }
    }

    public string Token
    {
        get => PlayerData.Token;
        set
        {
            SetProperty(PlayerData.Token, value, PlayerData, 
                (playerDate, token) => playerDate.Token = token);
            OverridePlayerData();
        }
    }

    public bool IsAi
    {
        get => PlayerData.IsAi;
        set
        {
            SetProperty(PlayerData.IsAi, value, PlayerData, 
                (playerData, isAi) => playerData.IsAi = isAi);
            SetProperty(PlayerData.IsHuman, !value, PlayerData, 
                (playerData, isHuman) => playerData.IsHuman = isHuman);
            OverridePlayerData();
        }
    }

    public bool IsHuman
    {
        get => PlayerData.IsHuman;
        set
        {
            SetProperty(PlayerData.IsHuman, value, PlayerData, 
                (playerData, isHuman) => playerData.IsHuman = isHuman);
            SetProperty(PlayerData.IsAi, !value, PlayerData, 
                (playerData, isAi) => playerData.IsAi = isAi);
            OverridePlayerData();
        }
    }

    public bool IsPlayersTurn
    {
        get => PlayerData.IsPlayersTurn;
        set
        {
            SetProperty(PlayerData.IsPlayersTurn, value, PlayerData,
                (playerData, isPlayersTurn) => playerData.IsPlayersTurn = isPlayersTurn);
            if (!value) return;
            WeakReferenceMessenger.Default.Send(new CurrentPlayerChangedMessage(this));
            OverridePlayerData();
        }
    }

    public bool IsWinner
    {
        get => PlayerData.IsWinner;
        set
        {
            SetProperty(PlayerData.IsWinner, value, PlayerData, 
                (playerData, isWinner) => playerData.IsWinner = isWinner);
            OverridePlayerData();
        }
    }

    public int Points
    {
        get => PlayerData.Points;
        set
        {
            SetProperty(PlayerData.Points, value, PlayerData, 
                (playerData, points) => playerData.Points = points);
            OverridePlayerData();
        }
    }

    public int GiveTokenPosition(List<string> tokenList, int clickedAreaId)
    {
        if (tokenList == null) throw new ArgumentNullException(nameof(tokenList));
        if (this.IsAi)
        {
            var area = _ai.FindBestMove(tokenList, Token, AiDifficultyLevel);
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