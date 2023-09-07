using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.CrossCutting.DataClasses;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Factories;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerGameBoardViewModel : ObservableObject, IPlayerGameBoardViewModel
{
    private int _animationCompletedCounter;
    private readonly List<IPlayerGameBoardAreaViewModel> _areas;
    private readonly IViewModelFactory<IPlayerGameBoardAreaViewModel> _areaFactory;

    public PlayerGameBoardViewModel(IViewModelFactory<IPlayerGameBoardAreaViewModel> areaFactory)
    {
        _areaFactory = areaFactory ?? throw new ArgumentNullException(nameof(areaFactory));
        _areas = GetAreas();
        PlayerGameBoardData = new PlayerGameBoardData();

        WeakReferenceMessenger.Default.Register<ContinueGameMessage>(this, (r, m) =>
        {
            _areas.ForEach(a => a.ResetToContinue());
        });
        WeakReferenceMessenger.Default.Register<StartNewGameMessage>(this, (r, m) =>
        {
            _areas.ForEach(a => a.ResetForNewGame());
        });
        WeakReferenceMessenger.Default.Register<PlayerGameBoardAreaPropertyChangedMessage>(this, (r, m) =>
        {
            PlayerGameBoardData.AreasData[m.Value.Id] = m.Value.PlayerGameBoardAreaData;
        });
        WeakReferenceMessenger.Default.Register<LoadGameSettingsMessage>(this, (r, m) =>
        {
            _areas.ForEach(a => a.Token = m.Value.PlayerGameBoardData.AreasData[a.Id].Token);
        });
    }

    public IReadOnlyList<IPlayerGameBoardAreaViewModel> Areas => _areas.AsReadOnly();

    public PlayerGameBoardData PlayerGameBoardData { get; set; }

    private List<IPlayerGameBoardAreaViewModel> GetAreas()
    {
        const int numberOfAreas = 9;
        var list = new List<IPlayerGameBoardAreaViewModel>();
        for (var i = 0; i < numberOfAreas; i++)
        {
            list.Add(_areaFactory.Create());
            list[i].Id = i;
        }
        return list;
    }

    public List<string> GetCurrentTokenList()
    {
        var currentTokenList = new List<string>();
        _areas.ForEach(a => { currentTokenList.Add(a.Token); });
        return currentTokenList;
    }

    public void AnimateWinAreas(List<bool> resultWinAreas)
    {
        _areas.ForEach(a => a.IsWinArea = resultWinAreas[a.Id]);
    }

    public void StartGameStartAnimation(bool isNewGame)
    {
        if (isNewGame)
        {
            _areas.ForEach(a => a.IsStartNewGameAnimation = true);
        }
        else
        {
            _areas.ForEach(a => a.IsStartSaveGameAnimation = true);
        }
    }

    [RelayCommand]
    private void GameBoardStartAnimationCompleted()
    {
        _animationCompletedCounter++;
        if (_animationCompletedCounter != 9) return;
        _animationCompletedCounter = 0;
        _areas.ForEach(area => area.IsInGame = true);
        WeakReferenceMessenger.Default.Send(new GameBoardStartAnimationCompletedMessage(this));
    }

    public async Task<bool> TrySetTokenTaskAsync(string token, bool isHuman, int areaId)
    {
        if (token == null) throw new ArgumentNullException(nameof(token));
        if (areaId is < 0 or > 9) throw new ArgumentOutOfRangeException(nameof(areaId));
        if (Areas[areaId].IsOccupied) return true;
        switch (isHuman)
        {
            case true:
                Areas[areaId].Token = token;
                Areas[areaId].IsOccupied = true;
                return false;
            case false:
                var rnd = new Random();
                var delayTime = rnd.Next(500, 2000);
                await Task.Delay(delayTime);
                Areas[areaId].Token = token;
                Areas[areaId].IsOccupied = true;
                return false;
        }
    }
}