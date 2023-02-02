using System.Windows.Input;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData
{
    public class GameMenuViewModelSampleData
    {
        public GameMenuViewModelSampleData()
        {
            var gameViewModel = new GameViewModelSampleData();
            PlayerX = gameViewModel.PlayingPlayerX;
            PlayerO = gameViewModel.PlayingPlayerO;
        }

        public PlayerViewModelSampleData PlayerX { get; set; }
        public PlayerViewModelSampleData PlayerO { get; set; }
        public ICommand SetupDefaultPlayerCommand { get; set; }
        public ICommand StartGameCommand { get; set; }
        public ICommand LoadSaveGameCommand { get; set; }
    }
}