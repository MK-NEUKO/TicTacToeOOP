using CommunityToolkit.Mvvm.Input;

namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameOverDialogViewModel
{
    string Message { get; set; }
    bool IsSelectNewGame { get; }
    IRelayCommand NewGameCommand { get; }
    IRelayCommand ContinueCommand { get; }
}