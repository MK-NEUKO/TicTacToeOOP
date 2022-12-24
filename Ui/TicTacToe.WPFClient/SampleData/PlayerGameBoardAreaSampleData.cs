using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.WPFClient.SampleData
{
    public class PlayerGameBoardAreaSampleData
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public bool IsWinArea { get; set; }
        public bool IsStartNewGameAnimation { get; set; }
        public bool IsStartSaveGameAnimation { get; set; }
        public bool IsGameRunning { get; set; }
        public ICommand AreaWasClickedCommand { get; set; }

        public PlayerGameBoardAreaSampleData()
        {
            
        }
    }
}
