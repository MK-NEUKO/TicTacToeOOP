namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData
{
    public class MainViewModelSampleData
    {
        public MainViewModelSampleData()
        {
            PlayerGameBoardViewModel = new PlayerGameBoardSampleData();
            PlayingPlayerViewModel = new PlayingPlayerViewModelSampleData();
            MenuViewModel = new MenuViewModelSampleData();
        }

        public PlayerGameBoardSampleData PlayerGameBoardViewModel { get; set; }
        public PlayingPlayerViewModelSampleData PlayingPlayerViewModel { get; set; }
        public MenuViewModelSampleData MenuViewModel { get; set; }
    }
}