using CommunityToolkit.Mvvm.ComponentModel;
using MichaelKoch.TicTacToe.Core.Interfaces;

namespace MichaelKoch.TicTacToe.Samples.ViewModel;

public class GameBoardAreaViewModel : ObservableObject, IGameBoardArea
{
    private int _id;
    private string _token;
    private bool _isWinArea;
    private bool _isOccupied;

    public int Id
    {
        get => _id;
        set => SetProperty(ref _id, value);
    }

    public string Token
    {
        get => _token;
        set => SetProperty(ref _token, value);
    }

    public bool IsWinArea
    {
        get => _isWinArea;
        set => SetProperty(ref _isWinArea, value);
    }

    public bool IsOccupied
    {
        get => _isOccupied;
        set => SetProperty(ref _isOccupied, value);
    }
}