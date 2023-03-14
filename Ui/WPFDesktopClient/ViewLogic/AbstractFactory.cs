using System;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public class AbstractFactory<TWindow> : IAbstractFactory<TWindow>
{
    private readonly Func<TWindow> _window;

    public AbstractFactory(Func<TWindow> window)
    {
        _window = window;
    }

    public TWindow Create()
    {
        return _window();
    }
}