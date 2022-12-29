namespace MichaelKoch.TicTacToe.Ui.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            PlayerGameBoardViewModel = new PlayerGameBoardViewModel();
        }

        public PlayerGameBoardViewModel PlayerGameBoardViewModel { get; }
    }
}
