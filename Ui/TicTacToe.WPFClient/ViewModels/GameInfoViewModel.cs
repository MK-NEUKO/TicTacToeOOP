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
        private Player _playerX;
        private Player _playerO;
        private int _numberOfTie;

        public GameInfoViewModel(IPlayerController playerController)
        {
            

            _playerX = playerController.PlayerX;
            _playerO = playerController.PlayerO;
        }

        public Player PlayerX { get => _playerX; set => _playerX = value; }
        public Player PlayerO { get => _playerO; set => _playerO = value; }
        public int NumberOfTie { get => _numberOfTie; set => _numberOfTie = value; }
    }
}
