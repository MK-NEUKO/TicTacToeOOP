using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Factories;

namespace MichaelKoch.TicTacToe.Ui.ViewModel;

public partial class GameOverDialogViewModel : ObservableObject, IGameOverDialogViewModel
{
    private readonly IWindowService<IGetSecureQueryDialogViewModel> _getSecureQueryDialog;
    private readonly IViewModelFactory<IGetSecureQueryDialogViewModel> _getSecureQueryViewModelFactory;

    [ObservableProperty] private string? _message;

    public GameOverDialogViewModel(IWindowService<IGetSecureQueryDialogViewModel> getSecureQueryDialog,
                                   IViewModelFactory<IGetSecureQueryDialogViewModel> getSecureQueryViewModelFactory)
    {
        _getSecureQueryDialog = getSecureQueryDialog;
        _getSecureQueryViewModelFactory = getSecureQueryViewModelFactory;
    }

    [RelayCommand]
    public void Continue()
    {
        throw new NotImplementedException(nameof(Continue));
    }

    [RelayCommand]
    public void NewGame()
    {
        var getSecureQueryDialogViewModel = _getSecureQueryViewModelFactory.Create();
        getSecureQueryDialogViewModel.Message = "Are you shure!";
        _getSecureQueryDialog.ShowDialog(getSecureQueryDialogViewModel);
    }
}