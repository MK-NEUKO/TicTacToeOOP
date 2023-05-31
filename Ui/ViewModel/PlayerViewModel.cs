using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Helper;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerViewModel : ObservableValidator, IPlayerViewModel
{
    private readonly IMinimaxAlgorithm _ai;
    private bool _isAi;
    private bool _isHuman;
    private bool _isPlayersTurn;
    [ObservableProperty] private bool _isWinner;
    [ObservableProperty] private string _name;
    [ObservableProperty] private int _points;
    [ObservableProperty] private string _token;

    public PlayerViewModel(IMinimaxAlgorithm ai)
    {
        _ai = ai;
        _name = string.Empty;
        _token = string.Empty;
        WeakReferenceMessenger.Default.Register<ContinueGameMessage>(this, (r, m) =>
        {
            IsWinner = false;
        });
    }

    public bool IsAi
    {
        get => _isAi;
        set
        {
            SetProperty(ref _isAi, value);
            SetProperty(ref _isHuman, !value);
        }
    }

    public bool IsHuman
    {
        get => _isHuman;
        set
        {
            SetProperty(ref _isHuman, value);
            SetProperty(ref _isAi, !value);
        }
    }

    public bool IsPlayersTurn
    {
        get => _isPlayersTurn;
        set
        {
            var isSetTrue = SetProperty(ref _isPlayersTurn, value)  && value;
            if (isSetTrue)
            {
                WeakReferenceMessenger.Default.Send(new CurrentPlayerChangedMessage(this));
            }
        }
    }

    public async Task<int> GiveTokenPositionTaskAsync(List<string> tokenList, int clickedAreaId = 10)
    {
        if (this.IsAi)
        {
            var area = -1;
            await Task.Run(() =>
            {
                // simulates the Ai
                // TODO: Implement the Minimax Algorithem in TicTacToeCore-Project
                //area = tokenList.FindIndex(t => t == string.Empty);

                area = _ai.FindBestMove(tokenList, Token);
            });
            return area;
        }

        if (this.IsHuman && clickedAreaId < 10)
            return clickedAreaId;
        return -1;
    }

    public void SetPoint()
    {
        if (this.IsWinner) this.Points++;
    }
}