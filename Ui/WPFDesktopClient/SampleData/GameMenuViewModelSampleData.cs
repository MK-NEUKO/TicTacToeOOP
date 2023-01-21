using System.Windows.Input;

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
        public ICommand SetupDefaultPlayerCommand { get; set; }
        public ICommand StartGameCommand { get; set; }
        public ICommand LoadSaveGameCommand { get; set; }
    }
}