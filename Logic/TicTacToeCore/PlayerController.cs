using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Data.DataStoring.Contarct;
using MichaelKoch.TicTacToe.Logik.TicTacToeCore.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MichaelKoch.TicTacToe.Logik.TicTacToeCore
{
    public class PlayerController : IPlayerController
    {
        private readonly IPlayerReposytory _playerReposytory;
        private Player _playerX;
        private Player _playerO;
        private readonly IGameBoard _board;
        private readonly IAI _aimimax;
        private int _gameIsTie;

        public int GameIsTie { get => _gameIsTie; }
        public Player PlayerX { get => _playerX; set => _playerX = value; }
        public Player PlayerO { get => _playerO; set => _playerO = value; }

        public PlayerController(IPlayerReposytory playerRepository, IGameBoard board, IAI aimimax)
        {
            _playerX = playerRepository.PlayerList[0];
            _playerO = playerRepository.PlayerList[1];
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

        public Player GiveCurrentPlayer()
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

        public void SetWinner()
        {
            if (_board.IsPlayerXWinner)
                _playerX.IsWinner = true;
            if (_board.IsPlayerOWinner)
                _playerO.IsWinner = true;
        }

    }

}
