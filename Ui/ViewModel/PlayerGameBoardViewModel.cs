using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerGameBoardViewModel : ObservableObject, IPlayerGameBoardViewModel
{
    public PlayerGameBoardViewModel(IGameBoardAreaFactory gameBoardAreaFactory, IGameEvaluator gameEvaluator)
    {
        Areas = gameBoardAreaFactory.CreateAreas();
    }

    public List<IPlayerGameBoardAreaViewModel> Areas { get; }

    public List<string> GetTokenList()
    {
        var tokenList = new List<string>();
        Areas.ForEach(a =>
        {
            if (a.Token != null) tokenList.Add(a.Token);
        });
        return tokenList;
    }

    public void AnimateWinAreas(List<bool> resultWinAreas)
    {
        Areas.ForEach(a => a.IsWinArea = resultWinAreas[a.Id]);
    }

    [RelayCommand]
    public void GameBoardStartAnimationCompleted()
    {
        Areas.ForEach(area => area.IsInGame = true);
        WeakReferenceMessenger.Default.Send(new GameBoardStartAnimationCompletedMessage(this));
    }

    public bool TrySetToken(string token, int areaId)
    {
        if (token == null) throw new ArgumentNullException(nameof(token));
        if (areaId is < 0 or > 9) throw new ArgumentOutOfRangeException(nameof(areaId));
        if (!string.IsNullOrWhiteSpace(Areas[areaId].Token)) return false;
        Areas[areaId].Token = token;
        return true;
    }
}