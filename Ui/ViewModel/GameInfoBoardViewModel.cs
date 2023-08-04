using System.Reflection.Metadata.Ecma335;
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
    private readonly PlayingPlayerData _playingPlayerData;

    [ObservableProperty]
    private IPlayerViewModel _playingPlayerX;

    [ObservableProperty]
    private IPlayerViewModel _playingPlayerO;

    [ObservableProperty] private string _firstInfoRowLabel;
    [ObservableProperty] private string _firstInfoRowValue;

    public GameInfoBoardViewModel(IViewModelFactory<IPlayerViewModel> playerFactory)
    {
        _playerFactory = playerFactory;
        _playingPlayerX = CreatePlayer("X");
        _playingPlayerO = CreatePlayer("O");
        _playingPlayerData = new PlayingPlayerData();
        
        WeakReferenceMessenger.Default.Register<StartGameButtonClickedMessage>(this, (r, m) =>
        {
            PlayingPlayerX = m.Value.Find(x => x.Token == "X") ?? throw new InvalidOperationException(nameof(PlayingPlayerX));
            PlayingPlayerO = m.Value.Find(x => x.Token == "O") ?? throw new InvalidOperationException(nameof(PlayingPlayerO));
            
        });
        WeakReferenceMessenger.Default.Register<StartNewGameMessage>(this, (r, m) =>
        {
            PlayingPlayerX = CreatePlayer("X");
            PlayingPlayerO = CreatePlayer("O");
            FirstInfoRowLabel = string.Empty;
            FirstInfoRowValue = string.Empty;
        });
        WeakReferenceMessenger.Default.Register<PlayerPropertyChangedMessage>(this, (r, m) =>
        {
            switch (m.Value.Token)
            {
                case "X":
                    _playingPlayerData.PlayerXData = m.Value.PlayerData;
                    break;
                case "O":
                    _playingPlayerData.PlayerOData = m.Value.PlayerData;
                    break;
            }
        });
    }

    

    public IPlayerViewModel CreatePlayer(string token)
    {
        var player = _playerFactory.Create();
        player.Token = token ?? throw new ArgumentNullException(nameof(token));
        player.Name = "Player" + player.Token;
        return player;
    }

    public void SavePlayer()
    {
        _playingPlayerData.SavePlayer();
    }
}