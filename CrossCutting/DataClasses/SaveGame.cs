namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses;

public class SaveGame
{
    public SaveGame()
    {
        GameInfoBoardData = new GameInfoBoardData();
    }

    public GameInfoBoardData GameInfoBoardData { get; set; }
}