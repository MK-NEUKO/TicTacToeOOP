using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Factories;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GameInfoBoardViewModel : ObservableObject, IGameInfoBoardViewModel
{
    private readonly IViewModelFactory<IPlayerViewModel> _playerFactory;

    [ObservableProperty]
    private IPlayerViewModel _playingPlayerX;

    [ObservableProperty]
    private IPlayerViewModel _playingPlayerO;

    public GameInfoBoardViewModel(IViewModelFactory<IPlayerViewModel> playerFactory)
    {
        _playerFactory = playerFactory;
        _playingPlayerX = CreatePlayer("X");
        _playingPlayerO = CreatePlayer("O");
        GameInfoBoardData = new GameInfoBoardData();
        
        WeakReferenceMessenger.Default.Register<StartGameButtonClickedMessage>(this, (r, m) =>
        {
            PlayingPlayerX = m.Value.Find(x => x.Token == "X") ?? throw new InvalidOperationException(nameof(PlayingPlayerX));
            PlayingPlayerO = m.Value.Find(x => x.Token == "O") ?? throw new InvalidOperationException(nameof(PlayingPlayerO));
            
        });
        WeakReferenceMessenger.Default.Register<StartNewGameMessage>(this, (r, m) =>
        {
            PlayingPlayerX = CreatePlayer("X");
            PlayingPlayerO = CreatePlayer("O");
        });
        WeakReferenceMessenger.Default.Register<PlayerPropertyChangedMessage>(this, (r, m) =>
        {
            switch (m.Value.Token)
            {
                case "X":
                    GameInfoBoardData.PlayerXData = m.Value.PlayerData;
                    break;
                case "O":
                    GameInfoBoardData.PlayerOData = m.Value.PlayerData;
                    break;
            }
        });
    }

    public GameInfoBoardData GameInfoBoardData { get; }

    public string FirstInfoRowLabel
    {
        get => GameInfoBoardData.FirstInfoRowLabel;
        set
        {
            SetProperty(GameInfoBoardData.FirstInfoRowLabel, value, GameInfoBoardData, (data, dataLabel) => data.FirstInfoRowLabel = dataLabel);
        }
    }

    public string FirstInfoRowValue
    {
        get => GameInfoBoardData.FirstInfoRowValue;
        set
        {
            SetProperty(GameInfoBoardData.FirstInfoRowValue, value, GameInfoBoardData, (data, dataValue) => data.FirstInfoRowValue = dataValue);
        }
    }

    public IPlayerViewModel CreatePlayer(string token)
    {
        var player = _playerFactory.Create();
        player.Token = token ?? throw new ArgumentNullException(nameof(token));
        player.Name = "Player" + player.Token;
        return player;
    }
}