using CommunityToolkit.Mvvm.ComponentModel;
using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.ViewModel;

public partial class GameInfoBoardViewModel : ObservableObject, IGameInfoBoardViewModel
{
    private readonly IPlayerService _playerService;
    private readonly IGameBoard _gameBoard;
    private List<string> _infoRowValues = ["1", "2"];

    public GameInfoBoardViewModel(IPlayer player, IPlayer opponent, IGameBoard gameBoard)
    {
        Player = player;
        Player.Token = "X";
        Player.IsCurrentPlayer = true;
        Opponent = opponent;
        _gameBoard = gameBoard;
        Opponent.Token = "O";
        Opponent.IsCurrentPlayer = false;
        _playerService = Core.Services.TicTacToe.GetPlayerService();
    }

    

    public IPlayer Player { get; }
    public IPlayer Opponent { get; }
    public List<string> InfoRowLabels { get; set; } = new List<string> { "Undecided", "Row-desc. 2" };

    public List<string> InfoRowValues
    {
        get => _infoRowValues; 
        set => SetProperty(ref _infoRowValues, value);
    } 

}