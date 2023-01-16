namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData
{
    public class MainViewModelSampleData
    {
        public MainViewModelSampleData()
        {
            PlayerGameBoardViewModel = new PlayerGameBoardSampleData();
            GameViewModel = new GameViewModelSampleData();
            MenuViewModel = new MenuViewModelSampleData();
        }

        public PlayerGameBoardSampleData PlayerGameBoardViewModel { get; set; }
        public GameViewModelSampleData  GameViewModel { get; set; }
        public MenuViewModelSampleData MenuViewModel { get; set; }
    }
}