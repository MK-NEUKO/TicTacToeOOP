using MichaelKoch.TicTacToe.Logik.TicTacToeCore;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient
{
    public class GameInfoViewModel : IGameInfoViewModel
    {
        private IPlayer _playerX;
        private IPlayer _playerO;
        private int _numberOfTie;

        public GameInfoViewModel(IPlayer playerX, IPlayer playerO)
        {
            if (playerX == null) throw new ArgumentNullException("PlayerX");
            if (playerO == null) throw new ArgumentNullException("PlayerO");

            _playerX = playerX;
            _playerO = playerO;
        }

        public IPlayer PlayerX { get => _playerX; set => _playerX = value; }
        public IPlayer PlayerO { get => _playerO; set => _playerO = value; }
        public int NumberOfTie { get => _numberOfTie; set => _numberOfTie = value; }
    }
}
