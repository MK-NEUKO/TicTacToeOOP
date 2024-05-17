namespace MichaelKoch.TicTacToe.Core.Interfaces;

public interface IGameBoardArea
{
    int Id { get; set; }
    string Token { get; set; }
    bool IsWinArea { get; set; }
    bool IsOccupied { get; set; }
}