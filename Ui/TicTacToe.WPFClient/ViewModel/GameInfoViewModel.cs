using System;
using System.Text;
using System.Collections.Generic;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public class GameInfoViewModel : ViewModelBase, IGameInfoViewModel
    {
        private IPlayerController _playerController;
        private Player _playerX;
        private Player _playerO;

        public GameInfoViewModel(IPlayerController playerController)
        {
            _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
            _playerX = _playerController.PlayerX;
            _playerO = _playerController.PlayerO;
        }

        public Player PlayerX
        {
            get => _playerX;
            set
            {
                _playerX = value;
                OnPropertyChanged();
            }
        }

        public Player PlayerO
        {
            get => _playerO;
            set
            {
                _playerO = value;
                OnPropertyChanged();
            }
        }

        public void InitializeNewPlayerList()
        {
            _playerController.GetNewPlayerList();
            PlayerX = _playerController.PlayerX;
            PlayerO = _playerController.PlayerO;
        }
    }
}
