namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData;

public class MainViewModelSampleData
{
    public MainViewModelSampleData()
    {
        PlayerGameBoardViewModel = new PlayerGameBoardSampleData();
        GameInfoBoardViewModel = new GameInfoBoardViewModelSampleData();
        MenuViewModel = new MenuViewModelSampleData();
    }

    public PlayerGameBoardSampleData PlayerGameBoardViewModel { get; set; }
    public GameInfoBoardViewModelSampleData GameInfoBoardViewModel { get; set; }
    public MenuViewModelSampleData MenuViewModel { get; set; }
}