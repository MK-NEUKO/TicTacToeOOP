using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.DesktopWPF.SampleData;

internal class DummyGameInfoBoardViewModel : IGameInfoBoardViewModel
{
    public IPlayer Player { get; set; }
    public IPlayer Opponent { get; set; }
    public List<string> InfoRowLabels { get; set; } = new List<string>{"Info-Row - 1", "Info-Row - 2"};
    public List<string> InfoRowValues { get; set; } = new List<string> { "any Value", "another Value" };
    public IRelayCommand TestCommand { get; }
    public IAsyncRelayCommand Test2Command { get; }
}