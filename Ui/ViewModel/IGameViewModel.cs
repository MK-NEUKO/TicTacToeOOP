namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public interface IGameViewModel
{
    PlayerViewModel PlayerX { get; set; }
    PlayerViewModel PlayerO { get; set; }
}