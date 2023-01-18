﻿using System.ComponentModel.DataAnnotations;
using CommunityToolkit.Mvvm.ComponentModel;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerViewModel : ObservableValidator, IPlayerViewModel
{
    [ObservableProperty] 
    [Required]
    [MaxLength(12)]
    private string? _name;

    [ObservableProperty]
    private string? _token;

    [ObservableProperty] 
    private bool _isWinner;

    [ObservableProperty] 
    private bool _isHuman;

    [ObservableProperty]
    private bool _isAi;

    [ObservableProperty]
    private bool _isPlayersTurn;

    [ObservableProperty]
    private int _points;

    public PlayerViewModel(string token)
    {
        _token = token;
        _name = "Player" + _token;
    }

    public string PlaceAToken()
    {
        return Token;
    }
}