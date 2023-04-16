namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IPlayingPlayerViewModel
{
    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayingPlayerViewModel._playingPlayerX"/>
    global::MichaelKoch.TicTacToe.Ui.ViewModel.Contract.IPlayerViewModel PlayingPlayerX { get; set; }

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayingPlayerViewModel._playingPlayerO"/>
    global::MichaelKoch.TicTacToe.Ui.ViewModel.Contract.IPlayerViewModel PlayingPlayerO { get; set; }

    IPlayerViewModel CreatePlayer(string token);
}