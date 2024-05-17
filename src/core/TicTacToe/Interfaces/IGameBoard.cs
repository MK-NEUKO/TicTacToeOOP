namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IGameBoard
{
    List<IGameBoardArea> Areas { get; set; }
    bool IsUndecided { get; set; }
}