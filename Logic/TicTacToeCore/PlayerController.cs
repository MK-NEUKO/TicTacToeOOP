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
        private readonly IGameBoard _board;
        private List<Player> _playerList;
        private Player _playerX;
        private Player _playerO;
        
        private readonly IAI _aimimax;
        private int _gameIsTie;

        

        public PlayerController(IPlayerReposytory playerRepository, IGameBoard board, IAI aimimax)
        {
            _playerReposytory = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));
            _board = board ?? throw new ArgumentNullException(nameof(board));
            _playerList = new List<Player>
            {
                new Player("PlayerX", false, true),
                new Player("PlayerO", false, true)
            };
            _playerX = _playerList[0];
            _playerO = _playerList[1];
            
            _aimimax = aimimax;
            
        }

        public IReadOnlyList<Player> PlayerList => _playerList.AsReadOnly();

        public void GetNewPlayerList() => _playerList = _playerReposytory.LoadNewPlayerList();

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
