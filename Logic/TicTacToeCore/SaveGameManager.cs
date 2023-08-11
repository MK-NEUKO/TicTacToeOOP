using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using System.Text.Json;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class SaveGameManager : ISaveGameManager
{
    public void SaveCurrentGame(GameInfoBoardData gameInfoBoardData)
    {
        var currentSaveGame = new SaveGame
        {
            GameInfoBoardData = gameInfoBoardData
        };

        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };

        var saveGame = JsonSerializer.Serialize(currentSaveGame, options);
    }
}
