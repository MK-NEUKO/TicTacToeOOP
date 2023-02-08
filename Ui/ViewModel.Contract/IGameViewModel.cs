namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameViewModel
{
    /// <inheritdoc cref="GameViewModel._playingPlayerX"/>
    global::MichaelKoch.TicTacToe.Ui.ViewModel.Contract.IPlayerViewModel PlayingPlayerX { get; set; }

    /// <inheritdoc cref="GameViewModel._playingPlayerO"/>
    global::MichaelKoch.TicTacToe.Ui.ViewModel.Contract.IPlayerViewModel PlayingPlayerO { get; set; }
}