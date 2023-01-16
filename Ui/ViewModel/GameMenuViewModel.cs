using CommunityToolkit.Mvvm.Input;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GameMenuViewModel : IGameMenuViewModel
{
    private IPlayerFactory _playerFactory;

    public GameMenuViewModel(IPlayerFactory playerFactory)
    {
        _playerFactory = playerFactory;
        PlayerX = _playerFactory.CreatePlayer("X");
        PlayerO = _playerFactory.CreatePlayer("O");
    }

    public PlayerViewModel PlayerX { get; set; }
    public PlayerViewModel PlayerO { get; set;}

    [RelayCommand]
    private void StartGame()
    {
        PlayerX.Name = "Horst";
    }
}