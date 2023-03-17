using CommunityToolkit.Mvvm.ComponentModel;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GetSecureQueryDialogViewModel : ObservableObject, IGetSecureQueryDialogViewModel
{
    [ObservableProperty] private string? _message;
}