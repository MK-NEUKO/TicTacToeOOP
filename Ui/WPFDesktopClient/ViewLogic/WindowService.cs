using System;
using System.Windows;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public abstract class WindowService<T> : IWindowService<T>
{
    private readonly IAbstractFactory<DialogWindow> _dialogAbstractFactory;
    private readonly Func<MainWindow> _owner;
    private DialogWindow? _dialogWindow;

    protected WindowService(IAbstractFactory<DialogWindow> dialogAbstractFactory, Func<MainWindow> owner)
    {
        _dialogAbstractFactory = dialogAbstractFactory;
        _owner = owner;
    }

    public virtual void ShowDialog(object viewModel, Action<bool>? callback = null)
    {
        _dialogWindow = _dialogAbstractFactory.Create();
        _dialogWindow.Owner = _owner();
        _dialogWindow.Content = CreateContent(viewModel);
        
        var result = _dialogWindow.ShowDialog();

        if (result == null) return;
        callback?.Invoke((bool)result);
    }

    public virtual void CloseDialog()
    {
        _dialogWindow?.Close();
    }

    public abstract FrameworkElement CreateContent(object viewModel);
}