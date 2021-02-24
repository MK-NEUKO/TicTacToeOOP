using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    public class PlayerController : IPlayerController
    {
        private readonly IPlayer _playerX;
        private readonly IPlayer _playerO;
        private readonly IGameBoard _board;
        private readonly IAI _aimimax;
        private int _gameIsTie;

        public int GameIsTie { get => _gameIsTie; }

        public PlayerController(IPlayer playerX, IPlayer playerO, IGameBoard board, IAI aimimax)
        {
            _playerX = playerX;
            _playerO = playerO;
            _board = board;
            _aimimax = aimimax;
            
        }

        public void ResetPlayers()
        {
            _playerX.Points = 0;
            _playerX.Name = "PlayerX";
            _playerX.InAction = true;

            _playerO.Points = 0;
            _playerO.Name = "PlayerO";
            _playerO.InAction = true;

            _gameIsTie = 0;
        }

        public IPlayer GiveCurrentPlayer()
        {
            if (_playerX.InAction)
                return _playerX;
            else if (_playerO.InAction)
                return _playerO;
            else
                return null;
        }

        public string GiveCurrentToken()
        {
            if (_playerX.InAction)
                return "X";
            else
                return "O";
        }

        public void ChangePlayer()
        {
            if (_playerX.InAction)
            {
                _playerX.InAction = false;
                _playerO.InAction = true;
            }
            else
            {
                _playerX.InAction = true;
                _playerO.InAction = false;
            }
        }

        public void GivePoints()
        {
            if (_board.IsPlayerXWinner)
                _playerX.Points++;
            if (_board.IsPlayerXWinner)
                _playerO.Points++;
            if (_board.IsGameTie)
                _gameIsTie++;
        }

    }

}
