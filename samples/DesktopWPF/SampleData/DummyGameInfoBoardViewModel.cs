using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.DesktopWPF.SampleData;

internal class DummyGameInfoBoardViewModel : IGameInfoBoardViewModel
{
    public IPlayerViewModel PlayerX { get; set; }
    public IPlayerViewModel PlayerO { get; set; }
    public List<string> InfoRowLabels { get; set; } = new List<string>{"Info-Row - 1", "Info-Row - 2"};
    public List<string> InfoRowValues { get; set; } = new List<string> { "any Value", "another Value" };
    public IRelayCommand TestCommand { get; }
    public IRelayCommand Test2Command { get; }
}