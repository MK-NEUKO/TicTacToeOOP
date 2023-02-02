using System.Threading;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData
{
    public class GameViewModelSampleData
    {
        public GameViewModelSampleData()
        {
            PlayingPlayerX = new PlayerViewModelSampleData()
                { Name = "PlayingPlayerX", IsAi = false, IsHuman = true, IsPlayersTurn = true, Token = "X", IsWinner = false, Points = 8 };

            PlayingPlayerO = new PlayerViewModelSampleData()
                { Name = "PlayingPlayerO", IsAi = true, IsHuman = false, IsPlayersTurn = false, Token = "O", IsWinner = false, Points = 34 };
        }

        public PlayerViewModelSampleData PlayingPlayerX { get; set; }
        public PlayerViewModelSampleData PlayingPlayerO { get; set; }
    }
}