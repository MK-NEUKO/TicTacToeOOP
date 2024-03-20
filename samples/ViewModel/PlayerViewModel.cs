using CommunityToolkit.Mvvm.ComponentModel;
using MichaelKoch.TicTacToe.Core.Entities;
using MichaelKoch.TicTacToe.Core.Enums;
using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.ViewModel;

public class PlayerViewModel : ObservableObject, IPlayerViewModel
{
    private readonly Player _player;

    public PlayerViewModel(IPlayerService playerService)
    {
        _player = playerService.GetDefaultPlayer();
    }

    public Player InnerPlayer => _player;

    public string Name
    {
        get => _player.Name;
        set => SetProperty(_player.Name, value, _player, (p, v) => p.Name = v);
    }

    public string Token
    {
        get => _player.Token;
        set => SetProperty(_player.Token, value, _player, (p, v) => p.Token = v);
    }

    public bool IsHuman
    {
        get => _player.IsHuman;
        set => SetProperty(_player.IsHuman, value, _player, (p, v) => p.IsHuman = v);
    }

    public bool IsAi
    {
        get => _player.IsAi;
        set => SetProperty(_player.IsAi, value, _player, (p, v) => p.IsAi = v);
    }

    public bool IsOnTheMove
    {
        get => _player.IsOnTheMove;
        set => SetProperty(_player.IsOnTheMove, value, _player, (p, v) => p.IsOnTheMove = v);
    }

    public bool IsWinner
    {
        get => _player.IsWinner;
        set => SetProperty(_player.IsWinner, value, _player, (p, v) => p.IsWinner = v);
    }

    public int Score
    {
        get => _player.Score;
        set => SetProperty(_player.Score, value, _player, (p, v) => p.Score = v);
    }

    public AiDifficultyLevel AiDifficultyLevel
    {
        get => _player.AiDifficultyLevel;
        set => SetProperty(_player.AiDifficultyLevel, value, _player, (p, v) => p.AiDifficultyLevel = v);
    }
}
