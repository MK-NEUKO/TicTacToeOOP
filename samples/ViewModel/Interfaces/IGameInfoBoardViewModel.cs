namespace MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;

public interface IGameInfoBoardViewModel
{
    IPlayerViewModel PlayerX { get; }
    IPlayerViewModel PlayerO { get; }
    List<string> InfoRowLabels { get; set; }
    List<string> InfoRowValues { get; set; }

    /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand"/> instance wrapping <see cref="GameInfoBoardViewModel.Test"/>.</summary>
    global::CommunityToolkit.Mvvm.Input.IRelayCommand TestCommand { get; }

    /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand"/> instance wrapping <see cref="GameInfoBoardViewModel.Test2"/>.</summary>
    global::CommunityToolkit.Mvvm.Input.IRelayCommand Test2Command { get; }
}