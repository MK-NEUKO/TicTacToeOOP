using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Documents;

namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient.SampleData
{
    public class GameBoardViewModelSampleData
    {
        public GameBoardViewModelSampleData()
        {
            Areas = new List<GameBoardAreaSampleData>
            {
                new GameBoardAreaSampleData() { Token = "O", Id = 0, IsStartNewGameAnimation = true},
                new GameBoardAreaSampleData() { Token = "X", Id = 1, IsWinArea = true},
                new GameBoardAreaSampleData() { Token = " ", Id = 2, IsStartSaveGameAnimation = true},
                new GameBoardAreaSampleData() { Token = "X", Id = 3, IsWinArea = true},
                new GameBoardAreaSampleData() { Token = "X", Id = 4,},
                new GameBoardAreaSampleData() { Token = " ", Id = 5 },
                new GameBoardAreaSampleData() { Token = "X", Id = 6 },
                new GameBoardAreaSampleData() { Token = " ", Id = 7 },
                new GameBoardAreaSampleData() { Token = "O", Id = 8 }
            };
        }
        
        public List<GameBoardAreaSampleData> Areas { get; set; }
    }
}
