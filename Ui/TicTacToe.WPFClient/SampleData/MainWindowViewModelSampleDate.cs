using System;
using System.Collections.Generic;
using System.Text;

namespace NEUKO.TicTacToe.WPFClient.SampleData
{
    public class MainWindowViewModelSampleDate
    {
        private readonly GameBoardViewModelSampleData _gameBoardViewModelSeplaData;

        public MainWindowViewModelSampleDate()
        {
            _gameBoardViewModelSeplaData = new GameBoardViewModelSampleData();
        }

        public GameBoardViewModelSampleData GameBoardViewModelSeplaData => _gameBoardViewModelSeplaData;
    }
}
