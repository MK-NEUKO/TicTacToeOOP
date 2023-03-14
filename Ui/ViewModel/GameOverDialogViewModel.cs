using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GameOverDialogViewModel : ObservableObject, IGameOverDialogViewModel
{
    [ObservableProperty] private string? _message;

    [RelayCommand]
    public void Continue()
    {
        throw new NotImplementedException(nameof(Continue));
    }

    [RelayCommand]
    public void NewGame()
    {
        throw new NotSupportedException(nameof(NewGame));
    }
}