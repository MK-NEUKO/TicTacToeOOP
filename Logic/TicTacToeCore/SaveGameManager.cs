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

    public void SaveCurrentGame(GameInfoBoardData gameInfoBoardData, PlayerGameBoardData playerGameBoardData)
    {
        var currentSaveGame = new SaveGame
        {
            GameInfoBoardData = gameInfoBoardData,
            PlayerGameBoardData = playerGameBoardData
        };

        _saveGameRepository.SaveGameInFile(currentSaveGame);
    }

    public SaveGame LoadLastSaveGame()
    {
        var lastGame = _saveGameRepository.LoadLastGameFromFile();
        return lastGame;
    }
}
