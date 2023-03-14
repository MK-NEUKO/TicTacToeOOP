namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public interface IAbstractFactory<TWindow>
{
    TWindow Create();
}