namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData
{
    public class MainViewModelSampleData
    {
        public MainViewModelSampleData()
        {
            PlayerGameBoardSampleData = new PlayerGameBoardSampleData();
            PlayingPlayerViewModelSampleData = new PlayingPlayerViewModelSampleData();
        }

        public PlayerGameBoardSampleData PlayerGameBoardSampleData { get; set; }
        public PlayingPlayerViewModelSampleData  PlayingPlayerViewModelSampleData { get; set; }
    }
}
