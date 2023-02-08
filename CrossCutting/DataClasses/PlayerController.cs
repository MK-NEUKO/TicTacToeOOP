using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Data.DataStoring.Contarct;
using System;
using System.Collections.Generic;
using System.Text;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore
{
    public class PlayerController : IPlayerController
    {
        private readonly IPlayerReposytory _playerRepository;
        private readonly IGameBoardManager _boardManager;
        private readonly IAI _aimimax;
        private Player _playerX;
        private Player _playerO;
        
        private int _gameIsTie;

        

        public PlayerController(IPlayerReposytory playerRepository, IGameBoardManager boardManager, IAI aimimax)
        {
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            _boardManager = boardManager ?? throw new ArgumentNullException(nameof(boardManager));
            _aimimax = aimimax ?? throw new ArgumentNullException(nameof(aimimax));
            _playerX = _playerRepository.LoadDefaultPlayerList()[0];
            _playerO = _playerRepository.LoadDefaultPlayerList()[1];
            
            
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
            if (_boardManager.IsPlayerXWinner)
                _playerX.Points++;
            if (_boardManager.IsPlayerOWinner)
                _playerO.Points++;
            if (_boardManager.IsGameTie)
                _gameIsTie++;
        }

        public void SetWinner()
        {
            if (_boardManager.IsPlayerXWinner)
                _playerX.IsWinner = true;
            if (_boardManager.IsPlayerOWinner)
                _playerO.IsWinner = true;
        }

    }

}
