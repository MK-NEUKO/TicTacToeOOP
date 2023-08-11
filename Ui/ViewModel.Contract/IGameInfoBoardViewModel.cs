using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameInfoBoardViewModel
{
    IPlayerViewModel PlayingPlayerX { get; set; }
    IPlayerViewModel PlayingPlayerO { get; set; }
    string FirstInfoRowLabel { get; set; }
    string FirstInfoRowValue { get; set; }
    GameInfoBoardData GameInfoBoardData { get; }
    IPlayerViewModel CreatePlayer(string token);
}