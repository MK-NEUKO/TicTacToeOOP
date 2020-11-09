﻿using System;
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

        public string GiveTheRightToken()
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
            if (_board.PlayerXIsWinner)
                _playerX.Points++;
            if (_board.PlayerOIsWinner)
                _playerO.Points++;
            if (_board.GameIsTie)
                _gameIsTie++;
        }

    }

}
