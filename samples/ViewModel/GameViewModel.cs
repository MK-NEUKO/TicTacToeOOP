using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;
using MichaelKoch.TicTacToe.Samples.ViewModel.Messenger;

namespace MichaelKoch.TicTacToe.Samples.ViewModel;

public class GameViewModel : ObservableObject
{
    private readonly IGameService _gameService;
    private readonly IGameBoard _gameBoard;
    private readonly IGameInfoBoardViewModel _gameInfoBoardViewModel;

    public GameViewModel(IGameService gameService, IGameBoard gameBoard, IGameInfoBoardViewModel gameInfoBoardViewModel)
    {
        _gameService = gameService;
        _gameBoard = gameBoard;
        _gameInfoBoardViewModel = gameInfoBoardViewModel;
        WeakReferenceMessenger.Default.Register<AreaWasClickedMessage>(this, async (r, m) =>
        {
            await StartGameAsync(m.Value.Id);
        });
    }

    public async Task StartGameAsync(int areaId)
    {
        var playerList = new List<IPlayer>();
        playerList.Add(_gameInfoBoardViewModel.Player);
        playerList.Add(_gameInfoBoardViewModel.Opponent);
        await _gameService.MakeAMoveAsync(_gameBoard.GameBoardAreas, playerList, areaId);
    }
}