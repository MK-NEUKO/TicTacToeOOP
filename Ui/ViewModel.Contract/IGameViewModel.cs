namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameViewModel
{
    IPlayerViewModel PlayingPlayerX { get; set; }
    IPlayerViewModel PlayingPlayerO { get; set; }
}