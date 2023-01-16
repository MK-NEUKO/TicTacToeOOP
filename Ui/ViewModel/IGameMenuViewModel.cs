namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public interface IGameMenuViewModel
{
    PlayerViewModel PlayerX { get; set; }
    PlayerViewModel PlayerO { get; set; }
}