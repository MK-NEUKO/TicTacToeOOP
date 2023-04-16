using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Factories;
using MichaelKoch.TicTacToe.Ui.ViewModel.Helper;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;



public partial class GameMenuViewModel : ObservableValidator, IGameMenuViewModel
{
    private bool _isStartButtonClicked;
    private bool _isGameStartAnimationCompleted;
    private readonly IViewModelFactory<IPlayerViewModel> _playerFactory;
    private readonly IViewModelFactory<IGetSecureQueryDialogViewModel> _getSecureQueryDialogViewModelFactory;
    private readonly IWindowService<IGetSecureQueryDialogViewModel> _getSecureQueryDialogService;

    private string? _namePlayerX;
    [ObservableProperty] private bool _isAiPlayerX;
    [ObservableProperty] private bool _isHumanPlayerX;
    [ObservableProperty] private bool _isPlayersTurnPlayerX;
    [ObservableProperty] private bool _isWinnerPlayerX;
    [ObservableProperty] private int _pointsPlayerX;
    [ObservableProperty] private string _tokenPlayerX;

    private string? _namePlayerO;
    [ObservableProperty] private bool _isAiPlayerO;
    [ObservableProperty] private bool _isHumanPlayerO;
    [ObservableProperty] private bool _isPlayersTurnPlayerO;
    [ObservableProperty] private bool _isWinnerPlayerO;
    [ObservableProperty] private int _pointsPlayerO;
    [ObservableProperty] private string _tokenPlayerO;

    public GameMenuViewModel(IViewModelFactory<IPlayerViewModel> playerFactory,
                             IViewModelFactory<IGetSecureQueryDialogViewModel> getSecureQueryDialogViewModelFactory,
                             IWindowService<IGetSecureQueryDialogViewModel> getSecureQueryDialogService)
    {
        _playerFactory = playerFactory ?? throw new ArgumentNullException(nameof(playerFactory));
        _getSecureQueryDialogViewModelFactory = getSecureQueryDialogViewModelFactory ?? throw new ArgumentNullException(nameof(getSecureQueryDialogViewModelFactory));
        _getSecureQueryDialogService = getSecureQueryDialogService ?? throw new ArgumentNullException(nameof(getSecureQueryDialogService));
        _tokenPlayerX = string.Empty;
        _tokenPlayerO = string.Empty;
        WeakReferenceMessenger.Default.Register<GameBoardStartAnimationCompletedMessage>(this, (r, m) =>
        {
            _isGameStartAnimationCompleted = true;
            StopGameCommand.NotifyCanExecuteChanged();
        });
        WeakReferenceMessenger.Default.Register<StartNewGameMessage>(this, Handler);
    }

    private void Handler(object recipient, StartNewGameMessage message)
    { 
        Reset.Invoke();
        _isStartButtonClicked = false;
        _isGameStartAnimationCompleted = false;
        StopGameCommand.NotifyCanExecuteChanged();
    }

    public Action Reset { get; set; } = null!;

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
        _isStartButtonClicked = true;
        StartGameCommand.NotifyCanExecuteChanged();
        StopGameCommand.NotifyCanExecuteChanged();
        var playerList = new List<IPlayerViewModel>
        {
            CreatePlayerX(),
            CreatePlayerO()
        };
        WeakReferenceMessenger.Default.Send(new StartGameButtonClickedMessage(playerList));
    }

    private bool CanStartGame()
    {
        return !HasErrors && !_isStartButtonClicked;
    }

    [RelayCommand(CanExecute = nameof(CanStopGame))]
    private void StopGame()
    {
        var getSecureQueryDialogViewModel = _getSecureQueryDialogViewModelFactory.Create();
        getSecureQueryDialogViewModel.Message = "Are you sure to stop the game! All points and settings will be lost";
        _getSecureQueryDialogService.ShowDialog(getSecureQueryDialogViewModel);
    }

    private bool CanStopGame()
    {
        return _isStartButtonClicked && _isGameStartAnimationCompleted;
    }

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
        var playerX = _playerFactory.Create();
        playerX.Token = "X";
        playerX.Name = NamePlayerX;
        playerX.IsAi = IsAiPlayerX;
        playerX.IsHuman = IsHumanPlayerX;
        playerX.IsPlayersTurn = IsPlayersTurnPlayerX;
        return playerX;
    }

    private IPlayerViewModel CreatePlayerO()
    {
        var playerO = _playerFactory.Create();
        playerO.Token = "O";
        playerO.Name = NamePlayerO;
        playerO.IsAi = IsAiPlayerO;
        playerO.IsHuman = IsHumanPlayerO;
        playerO.IsPlayersTurn = IsPlayersTurnPlayerO;
        return playerO;
    }
}