﻿using System;
using System.Text;
using System.Collections.Generic;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public class GameInfoViewModel : ViewModelBase, IGameInfoViewModel
    {
        private readonly IPlayerController _playerController;
        private Player _playerX;
        private Player _playerO;

        public GameInfoViewModel(IPlayerController playerController)
        {
            _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
            _playerX = _playerController.PlayerX;
            _playerO = _playerController.PlayerO;
        }

        public void RenewInfoBoard()
        {
            PlayerX = _playerController.PlayerX;
            PlayerO = _playerController.PlayerO;
        }

        public Player PlayerX
        {
            get => _playerX;
            private set
            {
                _playerX = value;
                OnPropertyChanged();
            }
        }
            
        public Player PlayerO
        {
            get => _playerO;
            private set
            {
                _playerO = value;
                OnPropertyChanged();
            }
        }
    }
}