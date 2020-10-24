using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.Core
{
    public class PlayerController : IPlayerController
    {
        private readonly IPlayer _playerX;
        private readonly IPlayer _playerO;

        public PlayerController(IPlayer playerX, IPlayer playerO)
        {
            _playerX = playerX;
            _playerO = playerO;
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

    }

}
