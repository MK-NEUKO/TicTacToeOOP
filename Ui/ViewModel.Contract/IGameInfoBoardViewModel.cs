namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameInfoBoardViewModel
{
    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayingPlayerViewModel._playingPlayerX"/>
    global::MichaelKoch.TicTacToe.Ui.ViewModel.Contract.IPlayerViewModel PlayingPlayerX { get; set; }

    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.PlayingPlayerViewModel._playingPlayerO"/>
    global::MichaelKoch.TicTacToe.Ui.ViewModel.Contract.IPlayerViewModel PlayingPlayerO { get; set; }

    string FirstInfoRowLabel { get; set; }
    string FirstInfoRowValue { get; set; }

    IPlayerViewModel CreatePlayer(string token);
}