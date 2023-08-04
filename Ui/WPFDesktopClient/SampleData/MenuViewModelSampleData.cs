namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.SampleData;

public class MenuViewModelSampleData
{
    public MenuViewModelSampleData()
    {
        GameMenuViewModel = new GameMenuViewModelSampleData();
    }

    public GameMenuViewModelSampleData GameMenuViewModel { get; set; }
}