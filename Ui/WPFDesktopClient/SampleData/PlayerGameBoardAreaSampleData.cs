using System.Windows.Input;
using MichaelKoch.TicTacToe.Ui.ViewModel;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData
{
    public class PlayerGameBoardAreaSampleData : IPlayerGameBoardAreaViewModel
    {
        public PlayerGameBoardAreaSampleData(int id)
        {
            Id = id;
            Token = " ";
        }

        public string? Token { get; set; }
        public int Id { get; set; }
        public bool IsWinArea { get; set; }
        public bool IsStartNewGameAnimation { get; set; }
        public bool IsStartSaveGameAnimation { get; set; }
        public ICommand AreaWasClickedCommand { get; set; } = null!;
    }
}