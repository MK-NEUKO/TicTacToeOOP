using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Samples.ViewModel.Messenger;

namespace MichaelKoch.TicTacToe.Samples.ViewModel;

public partial class GameBoardAreaViewModel : ObservableObject, IGameBoardArea
{
    private int _id;
    private string _token = string.Empty;
    private bool _isWinArea;
    private bool _isOccupied;

    [RelayCommand]
    public async Task AreaWasClicked()
    {
        await Task.Run(() =>
        {
            if(IsOccupied) return;
            WeakReferenceMessenger.Default.Send(new AreaWasClickedMessage(this));
        });
    }

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
