using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Ui.ViewModel;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

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
        public bool IsInGame { get; set; }
        public IRelayCommand PlaceATokenCommand { get; set; } = null!;
    }
}