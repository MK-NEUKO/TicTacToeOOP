using System.Collections.Generic;
using System.Threading.Tasks;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData
{
    public class PlayerViewModelSampleData : IPlayerViewModel
    {
        public string? Name { get; set; }
        public string? Token { get; set; }
        public bool IsHuman { get; set; }
        public bool IsAi { get; set; }
        public bool IsPlayersTurn { get; set; }
        public bool IsWinner { get; set; }
        public int Points { get; set; }
        public Task<int> GiveTokenPositionTaskAsync(List<string> tokenList, int clickedAreaId)
        {
            throw new System.NotImplementedException();
        }

        public void SetPoint()
        {
            throw new System.NotImplementedException();
        }
    }
}