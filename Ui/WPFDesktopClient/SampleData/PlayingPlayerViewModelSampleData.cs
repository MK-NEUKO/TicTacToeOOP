using System.Threading;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData
{
    public class PlayingPlayerViewModelSampleData
    {
        public PlayingPlayerViewModelSampleData()
        {
            PlayerX = new PlayerViewModelSampleData()
                { Name = "PlayerX", IsAi = false, IsHuman = true, IsPlayersTurn = true, Token = "X", IsWinner = false, Points = 8 };

            PlayerO = new PlayerViewModelSampleData()
                { Name = "PlayerO", IsAi = true, IsHuman = false, IsPlayersTurn = false, Token = "O", IsWinner = false, Points = 34 };
        }

        public PlayerViewModelSampleData PlayerX { get; set; }
        public PlayerViewModelSampleData PlayerO { get; set; }
    }
}
