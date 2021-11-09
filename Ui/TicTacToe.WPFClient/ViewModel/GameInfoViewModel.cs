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
        private readonly IPlayerController _playerController;
        private readonly Player _playerX;
        private readonly Player _playerO;

        public GameInfoViewModel(IPlayerController playerController)
        {
            _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));
            _playerX = _playerController.PlayerX;
            _playerO = _playerController.PlayerO;
        }

        public Player PlayerX => _playerX;

        public Player PlayerO => _playerO;
    }
}
