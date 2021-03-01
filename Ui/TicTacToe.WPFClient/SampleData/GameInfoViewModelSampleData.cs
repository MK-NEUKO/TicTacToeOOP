using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient.SampleData
{
    public class GameInfoViewModelSampleData
    {
        private readonly PlayerDummy _playerX;
        private readonly PlayerDummy _playerO;

        public GameInfoViewModelSampleData()
        {
            _playerX = new PlayerDummy()
            {
                IsHuman = true,
                InAction = true,
                Name = "PlayerX",
                Points = 23
            };

            _playerO = new PlayerDummy()
            {
                IsHuman = false,
                InAction = false,
                Name = "Hal",
                Points = 35
            };
        }

        public PlayerDummy PlayerO => _playerO;
        public PlayerDummy PlayerX => _playerX;
    }
}
