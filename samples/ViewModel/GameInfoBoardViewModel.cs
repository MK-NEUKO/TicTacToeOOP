using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Core.Entities;
using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.ViewModel;

public partial class GameInfoBoardViewModel : ObservableObject, IGameInfoBoardViewModel
{
    private readonly IPlayerService _playerService;
    public GameInfoBoardViewModel(IPlayerViewModel playerX, IPlayerViewModel playerO, IPlayerService playerService)
    {
        PlayerX = playerX;
        _playerO = playerO;
        _playerService = playerService;
    }

    [RelayCommand]
    private void Test()
    {
        PlayerX.Name = "Test";
        PlayerX.Token = "T";
        PlayerX.IsHuman = true;
        PlayerX.IsAi = false;
        PlayerX.IsOnTheMove = true;
        PlayerX.IsWinner = false;
        PlayerX.Score = 2;
    }

    [RelayCommand]
    private void Test2()
    {
        _playerService.ChangeIsOnTheMove(PlayerX.InnerPlayer, PlayerO.InnerPlayer);
    }

    public IPlayerViewModel PlayerX { get; }
    [ObservableProperty] private IPlayerViewModel _playerO;
    public List<string> InfoRowLabels { get; set; }
    public List<string> InfoRowValues { get; set; }
}