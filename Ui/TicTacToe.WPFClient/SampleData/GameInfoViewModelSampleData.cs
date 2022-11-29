using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient.SampleData
{
    public class GameInfoViewModelSampleData
    {
        private readonly PlayerDummy _playerX;
        private readonly PlayerDummy _playerO;
        private readonly int _pie;

        public GameInfoViewModelSampleData()
        {
            _playerX = new PlayerDummy()
            {
                IsHuman = true,
                InAction = true,
                Name = "Jens Hag",
                Points = 23
            };

            _playerO = new PlayerDummy()
            {
                IsHuman = false,
                InAction = false,
                Name = "Hal",
                Points = 35
            };

            _pie = 77;
        }

        public PlayerDummy PlayerO => _playerO;
        public PlayerDummy PlayerX => _playerX;
        public int Pie => _pie;

        public void RenewInfoBoard()
        {
            throw new NotImplementedException();
        }
    }
}
