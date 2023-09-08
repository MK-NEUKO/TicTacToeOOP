using System.Runtime.InteropServices;
using System.Text;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Data.DataStoring.Contract;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore;

public class SaveGameManager : ISaveGameManager
{
    private readonly ISaveGameRepository _saveGameRepository; 

    public SaveGameManager(ISaveGameRepository saveGameRepository)
    {
        _saveGameRepository = saveGameRepository;
    }

    public async Task SaveCurrentGameAsync(GameInfoBoardData gameInfoBoardData, PlayerGameBoardData playerGameBoardData)
    {
        var currentSaveGame = new SaveGame
        {
            GameInfoBoardData = gameInfoBoardData,
            PlayerGameBoardData = playerGameBoardData
        };

        await _saveGameRepository.SaveGameInFileAsync(currentSaveGame); 
    }

    public async Task<SaveGame> LoadLastSaveGameAsync()
    {
        return await _saveGameRepository.LoadLastGameFromFileAsync();
    }
}