namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public interface IWindowFactory<TWindow, TContent>
{
    TWindow CreateWindow();
    TContent CreateContent();
}