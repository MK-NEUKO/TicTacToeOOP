namespace MichaelKoch.TicTacToe.Samples.ViewModel;

public class MainWiewModel
{
    private PlayerViewModel _playerViewModel;

    public MainWiewModel(PlayerViewModel playerViewModel)
    {
        _playerViewModel = playerViewModel;
    }

    public PlayerViewModel PlayerViewModel { get; set; }
}