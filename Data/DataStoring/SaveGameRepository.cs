using System.Text.Json;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Data.DataStoring.Contract;

namespace MichaelKoch.TicTacToe.Data.DataStoring;

public class SaveGameRepository : ISaveGameRepository
{
    private const string SaveGameFileName = "SaveGame.json";

    public async Task SaveGameInFileAsync(SaveGame saveGame)
    {
        if (saveGame == null) throw new ArgumentNullException(nameof(saveGame));
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        await using var saveGameStream = File.Create(SaveGameFileName);
        await JsonSerializer.SerializeAsync(saveGameStream, saveGame, options);
        await saveGameStream.DisposeAsync();
    }

    public async Task<SaveGame> LoadLastGameFromFileAsync()
    {
        await using var openSaveGameStream = File.OpenRead(SaveGameFileName);
        var saveGame = await JsonSerializer.DeserializeAsync<SaveGame>(openSaveGameStream) ?? throw new InvalidDataException("The data could not be loaded!");
        await openSaveGameStream.DisposeAsync();
        return saveGame;
    }
}