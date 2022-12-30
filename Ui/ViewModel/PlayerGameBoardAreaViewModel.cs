﻿using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MichaelKoch.TicTacToe.Ui.ViewModel
{
    public class PlayerGameBoardAreaViewModel : ObservableObject, IPlayerGameBoardAreaViewModel
    {
        private string? _token;
        private bool _isWinArea;
        private bool _isStartNewGameAnimation;
        private bool _isStartSaveGameAnimation;
        
        public PlayerGameBoardAreaViewModel(int id)
        {
            Id = id;
            _token = string.Empty;
            AreaWasClickedCommand = new RelayCommand(() => { _token = "X"; });
        }

        public int Id { get; }

        public string? Token
        {
            get => _token;
            set => SetProperty(ref _token, value);
        }

        public bool IsWinArea
        {
            get => _isWinArea;
            set => SetProperty(ref _isWinArea, value);
        }

        public bool IsStartNewGameAnimation
        {
            get => _isStartNewGameAnimation;
            set => SetProperty(ref _isStartNewGameAnimation, value);
        }

        public bool IsStartSaveGameAnimation
        {
            get => _isStartSaveGameAnimation;
            set => SetProperty(ref _isStartSaveGameAnimation, value);
        }

        public ICommand? AreaWasClickedCommand { get; set; }
    }
}
