namespace MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

public interface IGetSecureQueryDialogViewModel
{
    /// <inheritdoc cref="MichaelKoch.TicTacToe.Ui.ViewModel.GetSecureQueryDialogViewModel._message"/>
    string? Message { get; set; }
}