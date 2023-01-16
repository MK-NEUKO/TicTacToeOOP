using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

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

    public IPlayerViewModel PlayerX { get; set; }
    public IPlayerViewModel PlayerO { get; set;}
}