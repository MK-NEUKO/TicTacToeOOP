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
        private readonly IPlayerReposytory _playerRepository;
        private readonly IGameBoard _board;
        private Player _playerX;
        private Player _playerO;
        
        private readonly IAI _aimimax;
        private int _gameIsTie;

        

        public PlayerController(IPlayerReposytory playerRepository, IGameBoard board, IAI aimimax)
        {
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            _board = board ?? throw new ArgumentNullException(nameof(board));
            _playerX = _playerRepository.LoadDefaultPlayerList()[0];
            _playerO = _playerRepository.LoadDefaultPlayerList()[1];
            
            _aimimax = aimimax;
            
        }

        public Player PlayerX => _playerX;

        public Player PlayerO => _playerO;

        public void GetNewPlayerList()
        {
            var playerList = _playerRepository.LoadNewPlayerList();
            _playerX = playerList[0];
            _playerO = playerList[1];
        }

        public void GetLastPlayerList()
        {
            var playerList = _playerRepository.LoadLastPlayerList();
            _playerX = playerList[0];
            _playerO = playerList[1];
        }

        public void ResetPlayers()
        {
            if (_playerX.IsWinner)
            {
                _playerO.InAction = true;
                _playerX.InAction = false;
            }
            if (_playerO.IsWinner)
            {
                _playerO.InAction = false;
                _playerX.InAction = true;
            }
            _playerX.IsWinner = false;
            _playerO.IsWinner = false;
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
            if (_board.IsPlayerOWinner)
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
