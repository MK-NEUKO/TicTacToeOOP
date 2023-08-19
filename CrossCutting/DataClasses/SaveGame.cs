namespace MichaelKoch.TicTacToe.CrossCutting.DataClasses;

public class SaveGame
{
    public SaveGame()
    {
        GameInfoBoardData = new GameInfoBoardData();
        PlayerGameBoardData = new PlayerGameBoardData();
    }

    public GameInfoBoardData GameInfoBoardData { get; set; }
    public PlayerGameBoardData PlayerGameBoardData { get; set; }
}