using System.Security.AccessControl;

namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses;

public class PlayerGameBoardAreaData
{
    public PlayerGameBoardAreaData()
    {
        Token = string.Empty;
    }

    public int Id { get; set; }
    public int CounterMouseEnter { get; set; }
    public bool CanShowIsOccupied { get; set; }
    public string Token { get; set; }
    public bool IsWinArea { get; set; }
    public bool IsOccupied { get; set; }
    public bool IsStartSaveGameAnimation { get; set; }
}