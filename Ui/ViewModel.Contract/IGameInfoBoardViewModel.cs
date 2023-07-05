namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameInfoBoardViewModel
{
    IPlayerViewModel PlayingPlayerX { get; set; }
    IPlayerViewModel PlayingPlayerO { get; set; }
    string FirstInfoRowLabel { get; set; }
    string FirstInfoRowValue { get; set; }
    IPlayerViewModel CreatePlayer(string token);
}