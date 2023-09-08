using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;

public interface ISaveGameManager
{
    Task SaveCurrentGameAsync(GameInfoBoardData gameInfoBoardData, PlayerGameBoardData playerGameBoardData);
    Task<SaveGame> LoadLastSaveGameAsync();
}