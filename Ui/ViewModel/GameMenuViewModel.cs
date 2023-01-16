using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

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

    public IPlayerViewModel PlayerX { get; set; }
    public IPlayerViewModel PlayerO { get; set;}

    [RelayCommand]
    private void StartGame()
    {
        PlayerX.Name = "Horst";
    }
}