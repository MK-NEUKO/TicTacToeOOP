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
        public bool IsOccupied { get; set; }
        public bool IsStartNewGameAnimation { get; set; }
        public bool IsStartSaveGameAnimation { get; set; }
        public bool IsInGame { get; set; }
        public bool CanShowIsOccupied { get; set; }
        public IRelayCommand AreaWasClickedCommand { get; set; } = null!;
        public IRelayCommand MouseEnterForShowIsOccupiedCommand { get; set; } = null!;
        public void ResetToContinue()
        {
            throw new System.NotImplementedException();
        }
    }
}