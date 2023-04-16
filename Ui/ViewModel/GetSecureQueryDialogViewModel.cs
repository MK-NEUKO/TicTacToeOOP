using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GetSecureQueryDialogViewModel : ObservableObject, IGetSecureQueryDialogViewModel
{
    private readonly IWindowService<IGetSecureQueryDialogViewModel> _ownDialogService;
    [ObservableProperty] private string? _message;

    public GetSecureQueryDialogViewModel(IWindowService<IGetSecureQueryDialogViewModel> ownDialogService)
    {
        _ownDialogService = ownDialogService;
    }

    [RelayCommand]
    public void Ok()
    {
        WeakReferenceMessenger.Default.Send(new StartNewGameMessage(true));
        _ownDialogService.CloseDialog();
    }

    [RelayCommand]
    public void Cancel()
    {
        _ownDialogService.CloseDialog();
    }
}