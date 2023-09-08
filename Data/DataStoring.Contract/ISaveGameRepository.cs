using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Data.DataStoring.Contract;

public interface ISaveGameRepository
{
    Task SaveGameInFileAsync(SaveGame saveGame);
    Task<SaveGame> LoadLastGameFromFileAsync();
}