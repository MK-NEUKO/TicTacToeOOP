using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GetSecureQueryDialogViewModel : ObservableObject, IGetSecureQueryDialogViewModel
{
    private readonly IWindowService<IGetSecureQueryDialogViewModel> _ownDialogService;
    [ObservableProperty] private string _message;

    public GetSecureQueryDialogViewModel(IWindowService<IGetSecureQueryDialogViewModel> ownDialogService)
    {
        _ownDialogService = ownDialogService;
        _message = string.Empty;
    }

    public bool DialogResult { get; private set; }

    [RelayCommand]
    public void Ok()
    {
        DialogResult = true;
        WeakReferenceMessenger.Default.Send(new StartNewGameMessage(true));
        _ownDialogService.CloseDialog();
    }

    [RelayCommand]
    public void Cancel()
    {
        DialogResult = false;
        _ownDialogService.CloseDialog();
    }
}