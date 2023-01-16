namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameViewModel
{
    IPlayerViewModel PlayerX { get; set; }
    IPlayerViewModel PlayerO { get; set; }
}