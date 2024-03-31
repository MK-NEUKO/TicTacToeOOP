namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IGameBoard
{
    List<IGameBoardArea> GameBoardAreas { get; set; }
}