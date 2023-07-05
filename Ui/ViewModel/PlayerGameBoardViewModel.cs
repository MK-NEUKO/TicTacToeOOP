using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
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

    public PlayerGameBoardViewModel(IGameEvaluator gameEvaluator, 
                                    IViewModelFactory<IPlayerGameBoardAreaViewModel> areaFactory)
    {
        _areaFactory = areaFactory ?? throw new ArgumentNullException(nameof(areaFactory));
        _areas = GetAreas();
        WeakReferenceMessenger.Default.Register<ContinueGameMessage>(this, (r, m) =>
        {
            _areas.ForEach(a => a.ResetToContinue());
        });
        WeakReferenceMessenger.Default.Register<StartNewGameMessage>(this, (r, m) =>
        {
            _areas.ForEach(a => a.ResetForNewGame());
        });
    }

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

    public IReadOnlyList<IPlayerGameBoardAreaViewModel> Areas => _areas.AsReadOnly();

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

    public void StartGameStartAnimation()
    {
        _areas.ForEach(a => a.IsStartNewGameAnimation = true);
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