using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Factories;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayingPlayerViewModel : ObservableObject, IPlayingPlayerViewModel
{
    private readonly IViewModelFactory<IPlayerViewModel> _playerFactory;

    [ObservableProperty] private IPlayerViewModel _playingPlayerX;
    [ObservableProperty] private IPlayerViewModel _playingPlayerO;

    public PlayingPlayerViewModel(IViewModelFactory<IPlayerViewModel> playerFactory)
    {
        _playerFactory = playerFactory;
        _playingPlayerX = CreatePlayer("X");
        _playingPlayerO = CreatePlayer("O");
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
    }

    public IPlayerViewModel CreatePlayer(string token)
    {
        var player = _playerFactory.Create();
        player.Token = token ?? throw new ArgumentNullException(nameof(token));
        player.Name = "Player" + player.Token;
        return player;
    }
}