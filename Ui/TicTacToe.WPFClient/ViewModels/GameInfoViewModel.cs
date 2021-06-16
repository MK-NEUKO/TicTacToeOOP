using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient
{
    public class GameInfoViewModel : IGameInfoViewModel
    {
        private IPlayerController _playerController;
        private readonly Player _playerX;
        private readonly Player _playerO;

        public GameInfoViewModel(IPlayerController playerController)
        {
            _playerController = playerController ?? throw new ArgumentNullException(nameof(playerController));

            _playerX = _playerController.PlayerList[0];
            _playerO = _playerController.PlayerList[1];
            
        }

        public Player PlayerX => _playerX;
        public Player PlayerO => _playerO;

        public void InitializeNewPlayerList()
        {
            _playerController.GetNewPlayerList();
        }
    }
}
