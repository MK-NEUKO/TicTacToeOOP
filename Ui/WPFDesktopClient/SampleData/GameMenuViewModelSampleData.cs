namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData
{
    public class GameMenuViewModelSampleData
    {
        public GameMenuViewModelSampleData()
        {
            var playingPlayers = new GameViewModelSampleData();
            PlayerX = playingPlayers.PlayerX;
            PlayerO = playingPlayers.PlayerO;
        }

        public PlayerViewModelSampleData PlayerX { get; set; }
        public PlayerViewModelSampleData PlayerO { get; set; }
    }
}