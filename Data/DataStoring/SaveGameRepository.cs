using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using System.Text.Json;
using MichaelKoch.TicTacToe.Data.DataStoring.Contract;

namespace MichaelKoch.TicTacToe.Data.DataStoring;

public class SaveGameRepository : ISaveGameRepository
{
    public void SaveGameInFile(SaveGame saveGame)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        var jsonString = JsonSerializer.Serialize(saveGame, options);
        File.WriteAllText("SaveGame.json", jsonString);
    }
}