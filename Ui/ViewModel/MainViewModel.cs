namespace MichaelKoch.TicTacToe.Ui.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel(IPlayerGameBoardViewModel playerGameBoardViewModel)
        {
            PlayerGameBoardViewModel = playerGameBoardViewModel;
        }

        public IPlayerGameBoardViewModel PlayerGameBoardViewModel { get; }
    }
}
