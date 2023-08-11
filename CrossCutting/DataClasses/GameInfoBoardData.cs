using System.Text.Json;

namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses;

public class GameInfoBoardData
{
    public GameInfoBoardData()
    {
        PlayerXData = new PlayerData();
        PlayerOData = new PlayerData();
        FirstInfoRowLabel = string.Empty;
        FirstInfoRowValue = string.Empty;
    }

    public PlayerData PlayerXData { get; set; }
    public PlayerData PlayerOData { get; set; }
    public string FirstInfoRowLabel { get; set; }
    public string FirstInfoRowValue { get; set; }
}