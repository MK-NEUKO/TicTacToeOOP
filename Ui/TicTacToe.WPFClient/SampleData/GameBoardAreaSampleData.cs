namespace MichaelKoch.TicTacToe.Ui.TicTacToe.WPFClient.SampleData
{
    public class GameBoardAreaSampleData
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public bool IsWinArea { get; set; }
        public bool IsStartNewGameAnimation { get; set; }
        public bool IsStartSaveGameAnimation { get; set; }
        public bool IsGameRunning { get; set; }

        public GameBoardAreaSampleData()
        {
            IsWinArea = false;
        }
    }
}
