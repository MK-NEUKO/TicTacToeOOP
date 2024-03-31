using CommunityToolkit.Mvvm.ComponentModel;
using MichaelKoch.TicTacToe.Core.Enums;
using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.ViewModel;

public class PlayerViewModel : ObservableObject, IPlayer
{
    private string _name;
    private string _token;
    private bool _isHuman;
    private bool _isAi;
    private bool _isOnTheMove;
    private bool _isWinner;
    private int _score;
    private AiDifficultyLevel _aiDifficultyLevel;

    public string Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string Token
    {
        get => _token;
        set => SetProperty(ref _token, value);
    }

    public bool IsHuman
    {
        get => _isHuman;
        set => SetProperty(ref _isHuman, value);
    }

    public bool IsAi
    {
        get => _isAi;
        set => SetProperty(ref _isAi, value);
    }

    public bool IsOnTheMove
    {
        get => _isOnTheMove;
        set => SetProperty(ref _isOnTheMove, value);
    }

    public bool IsWinner
    {
        get => _isWinner;
        set => SetProperty(ref _isWinner, value);
    }

    public int Score
    {
        get => _score;
        set => SetProperty(ref _score, value);
    }

    public AiDifficultyLevel AiDifficultyLevel
    {
        get => _aiDifficultyLevel;
        set => SetProperty(ref _aiDifficultyLevel, value);
    }
}
