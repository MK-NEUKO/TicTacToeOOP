using MichaelKoch.TicTacToe.Core.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;

public interface IGameInfoBoardViewModel
{
    IPlayer Player { get; }
    IPlayer Opponent { get; }
    List<string> InfoRowLabels { get; set; }
    List<string> InfoRowValues { get; set; }
}