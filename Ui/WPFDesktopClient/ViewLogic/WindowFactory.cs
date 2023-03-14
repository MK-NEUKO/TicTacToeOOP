using System;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public class WindowFactory<TWindow, TContent> : IWindowFactory<TWindow, TContent>
{
    private readonly Func<TWindow> _window;
    private readonly Func<TContent> _content;

    public WindowFactory(Func<TWindow> window, Func<TContent> content)
    {
        _window = window;
        _content = content;
    }

    public TWindow CreateWindow()
    {
        return _window();
    }

    public TContent CreateContent()
    {
        return _content();
    }
}