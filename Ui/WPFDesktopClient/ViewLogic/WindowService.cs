using System;
using System.Windows;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public abstract class WindowService : IWindowService
{
    private readonly IAbstractFactory<DialogWindow> _dialogAbstractFactory;
    private readonly Func<MainWindow> _owner;

    protected WindowService(IAbstractFactory<DialogWindow> dialogAbstractFactory, Func<MainWindow> owner)
    {
        _dialogAbstractFactory = dialogAbstractFactory;
        _owner = owner;
    }

    public virtual void ShowDialog(object viewModel)
    {
        var shellWindow = _dialogAbstractFactory.Create();
        shellWindow.Owner = _owner();
        shellWindow.Content = CreateContent(viewModel);

        shellWindow.ShowDialog();
    }

    public abstract FrameworkElement CreateContent(object viewModel);
}