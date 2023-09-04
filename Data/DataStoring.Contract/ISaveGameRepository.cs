using MichaelKoch.TicTacToe.CrossCutting.DataClasses;

namespace MichaelKoch.TicTacToe.Data.DataStoring.Contract;

public interface ISaveGameRepository
{
    void SaveGameInFile(SaveGame saveGame);
    SaveGame LoadLastGameFromFile();
}