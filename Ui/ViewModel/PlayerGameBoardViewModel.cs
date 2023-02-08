using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerGameBoardViewModel : ObservableObject, IPlayerGameBoardViewModel
{
    private readonly IGameBoardEvaluator _gameBoardEvaluator;

    public PlayerGameBoardViewModel(IGameBoardAreaFactory gameBoardAreaFactory, IGameBoardEvaluator gameBoardEvaluator)
    {
        _gameBoardEvaluator = gameBoardEvaluator;
        Areas = gameBoardAreaFactory.CreateAreas();
    }

    public List<IPlayerGameBoardAreaViewModel> Areas { get; }
    public bool IsWinner { get; private set; }
    public bool IsGameDraw { get; private set; }

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

    public bool EvaluateGameState(string currentToken)
    {
        var tokenList = new List<string>();
        Areas.ForEach(a => tokenList.Add(a.Token));
        var result = _gameBoardEvaluator.DetermineWinner(tokenList, currentToken);
        // set evaluation result
        Areas.ForEach(a => a.IsWinArea = result[a.Id]);
        IsWinner = result[9];
        //IsGameDraw = result[10];
        return IsWinner;
    }

   
}