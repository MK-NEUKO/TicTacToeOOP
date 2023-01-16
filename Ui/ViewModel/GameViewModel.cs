using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GameViewModel : ObservableObject, IGameViewModel
{
    private readonly IPlayerFactory _playerFactory;

    public GameViewModel(IPlayerFactory playerFactory)
    {
        _playerFactory = playerFactory;
        PlayerX = playerFactory.CreatePlayer("X");
        PlayerO = playerFactory.CreatePlayer("O");
    }

    public PlayerViewModel PlayerX { get; set; }
    public PlayerViewModel PlayerO { get; set;}
}