using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Helper;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;



public partial class GameMenuViewModel : ObservableValidator, IGameMenuViewModel
{
    private readonly IPlayerFactory _playerFactory;

    private string? _namePlayerX;
    [ObservableProperty] private bool _isAiPlayerX;

    [ObservableProperty] private bool _isHumanPlayerX;

    [ObservableProperty] private bool _isPlayersTurnPlayerX;

    [ObservableProperty] private bool _isWinnerPlayerX;

    [ObservableProperty] private int _pointsPlayerX;

    [ObservableProperty] private string? _tokenPlayerX;

    private string? _namePlayerO;
    [ObservableProperty] private bool _isAiPlayerO;

    [ObservableProperty] private bool _isHumanPlayerO;

    [ObservableProperty] private bool _isPlayersTurnPlayerO;

    [ObservableProperty] private bool _isWinnerPlayerO;

    [ObservableProperty] private int _pointsPlayerO;

    [ObservableProperty] private string? _tokenPlayerO;

    public GameMenuViewModel(IPlayerFactory playerFactory)
    {
        _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
    }

    [ValidatePlayerName]
    public string? NamePlayerX
    {
        get => _namePlayerX;
        set
        {
            SetProperty(ref _namePlayerX, value, true);
            StartGameCommand.NotifyCanExecuteChanged();
        }
    }

    [ValidatePlayerName]
    public string? NamePlayerO
    {
        get => _namePlayerO;
        set
        {
            SetProperty(ref _namePlayerO, value, true);
            StartGameCommand.NotifyCanExecuteChanged();
        }
    }

    [RelayCommand(CanExecute = nameof(CanStartGame))]
    private void StartGame()
    {
        var playerList = new List<IPlayerViewModel>();
        playerList.Add(CreatePlayerX());
        playerList.Add(CreatePlayerO());
        WeakReferenceMessenger.Default.Send(new StartGameMessage(playerList));
    }

    private bool CanStartGame => !HasErrors;

    [RelayCommand]
    private void SetupDefaultPlayer()
    {
        NamePlayerX = "PlayerX";
        IsHumanPlayerX = true;
        IsPlayersTurnPlayerX = true;
        NamePlayerO = "PlayerO";
        IsAiPlayerO = true;
    }

    private IPlayerViewModel CreatePlayerX()
    {
        var playerX = _playerFactory.CreatePlayer("X");
        playerX.Name = NamePlayerX;
        playerX.IsAi = IsAiPlayerX;
        playerX.IsHuman = IsAiPlayerX;
        playerX.IsPlayersTurn = IsPlayersTurnPlayerX;
        return playerX;
    }

    private IPlayerViewModel CreatePlayerO()
    {
        var playerO = _playerFactory.CreatePlayer("O");
        playerO.Name = NamePlayerO;
        playerO.IsAi = IsAiPlayerO;
        playerO.IsHuman = IsAiPlayerO;
        playerO.IsPlayersTurn = IsPlayersTurnPlayerO;
        return playerO;
    }
}