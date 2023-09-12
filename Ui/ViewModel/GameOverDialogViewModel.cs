using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Factories;
using MichaelKoch.TicTacToe.Ui.ViewModel.Messages;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GameOverDialogViewModel : ObservableObject, IGameOverDialogViewModel
{
    private readonly IWindowService<IGetSecureQueryDialogViewModel> _getSecureQueryDialogService;
    private readonly IViewModelFactory<IGetSecureQueryDialogViewModel> _getSecureQueryViewModelFactory;
    private readonly IWindowService<IGameOverDialogViewModel> _ownDialogService;

    [ObservableProperty] private string _message;
    [ObservableProperty] private bool _isSelectNewGame;

    public GameOverDialogViewModel(IWindowService<IGetSecureQueryDialogViewModel> getSecureQueryDialogService,
                                   IViewModelFactory<IGetSecureQueryDialogViewModel> getSecureQueryViewModelFactory,
                                   IWindowService<IGameOverDialogViewModel> ownDialogService)
    {
        _message = string.Empty;
        _getSecureQueryDialogService = getSecureQueryDialogService;
        _getSecureQueryViewModelFactory = getSecureQueryViewModelFactory;
        _ownDialogService = ownDialogService;
    }

    [RelayCommand]
    public void Continue()
    {
        WeakReferenceMessenger.Default.Send(new ContinueGameMessage(true));
        IsSelectNewGame = false;
        _ownDialogService.CloseDialog();
    }

    [RelayCommand]
    public void NewGame()
    {
        IsSelectNewGame = true;
        var getSecureQueryDialogViewModel = _getSecureQueryViewModelFactory.Create();
        getSecureQueryDialogViewModel.Message = "Are you sure! All points and settings will be lost.";
        _getSecureQueryDialogService.ShowDialog(getSecureQueryDialogViewModel, result =>
        {
            if(result) _ownDialogService.CloseDialog();
        });
    }
}