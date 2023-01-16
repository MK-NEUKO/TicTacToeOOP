using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class PlayerGameBoardAreaViewModel : ObservableObject, IPlayerGameBoardAreaViewModel
{
    [ObservableProperty]
    private int _id;

    [ObservableProperty]
    private string? _token;

    [ObservableProperty]
    private bool _isWinArea;

    [ObservableProperty]
    private bool _isStartNewGameAnimation;

    [ObservableProperty]
    private bool _isStartSaveGameAnimation;
        
    public PlayerGameBoardAreaViewModel(int id)
    {
        _id = id;
        _token = string.Empty;
        AreaWasClickedCommand = new RelayCommand
        (
            // this is for testing purposes only, not a final implementation.
            () => { Token = Token is "X" or " " ? "O" : "X"; }
        );
    }

    public ICommand AreaWasClickedCommand { get; set; }
}