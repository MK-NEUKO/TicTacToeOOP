using System.Text.Json;

namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses;

public class PlayingPlayerData
{
    public PlayingPlayerData()
    {
        PlayerXData = new PlayerData();
        PlayerOData = new PlayerData();

    }

    public PlayerData PlayerXData { get; set; }
    public PlayerData PlayerOData { get; set; }


    public void SavePlayer()
    {
        string playerDate = JsonSerializer.Serialize(PlayerXData);
        playerDate += JsonSerializer.Serialize(PlayerOData);
    }
}