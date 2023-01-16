using System.Collections.Generic;
using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.WPFClient.SampleData
{
    public class PlayerGameBoardViewModelSampleData
    {
        public PlayerGameBoardViewModelSampleData()
        {
            Areas = new List<PlayerGameBoardAreaSampleData>
            {
                new PlayerGameBoardAreaSampleData() { Token = "O", Id = 0, IsStartNewGameAnimation = true},
                new PlayerGameBoardAreaSampleData() { Token = "X", Id = 1, IsWinArea = true},
                new PlayerGameBoardAreaSampleData() { Token = " ", Id = 2, IsStartSaveGameAnimation = true},
                new PlayerGameBoardAreaSampleData() { Token = "X", Id = 3, IsWinArea = true},
                new PlayerGameBoardAreaSampleData() { Token = "X", Id = 4,},
                new PlayerGameBoardAreaSampleData() { Token = " ", Id = 5 },
                new PlayerGameBoardAreaSampleData() { Token = "X", Id = 6 },
                new PlayerGameBoardAreaSampleData() { Token = " ", Id = 7 },
                new PlayerGameBoardAreaSampleData() { Token = "O", Id = 8 }
            };
        }
        
        public List<PlayerGameBoardAreaSampleData> Areas { get; set; }
        public bool IsGameDecided { get; set; }
        public ICommand ContinueCommand { get; set; }
        public ICommand StartGameAnimationCompletedCommand { get; set; }
    }
}
