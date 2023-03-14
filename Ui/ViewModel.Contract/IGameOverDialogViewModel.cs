namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGameOverDialogViewModel
{
    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.GameOverDialogViewModel._message"/>
    string? Message { get; set; }

    /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand"/> instance wrapping <see cref="MichaelKoch.TicTacToe.Ui.ViewModel.GameOverDialogViewModel.NewGame()"/>.</summary>
    global::CommunityToolkit.Mvvm.Input.IRelayCommand NewGameCommand { get; }

    /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand"/> instance wrapping <see cref="MichaelKoch.TicTacToe.Ui.ViewModel.GameOverDialogViewModel.Continue()"/>.</summary>
    global::CommunityToolkit.Mvvm.Input.IRelayCommand ContinueCommand { get; }
}