using MichaelKoch.TicTacToe.Core.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.DesktopWPF.SampleData;

public class DummyGameBoardArea : IGameBoardArea
{
    public int Id { get; set; }
    public string Token { get; set; }
    public bool IsWinArea { get; set; }
    public bool IsOccupied { get; set; }
}