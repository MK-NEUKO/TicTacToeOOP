using System;
using System.Collections.Generic;
using System.Text;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient.SampleData
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
