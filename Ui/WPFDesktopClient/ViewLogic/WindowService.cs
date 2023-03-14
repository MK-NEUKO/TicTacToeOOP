using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.InteropServices.ObjectiveC;
using System.Windows;
using MichaelKoch.TicTacToe.Ui.ViewModel;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.WPFDesktopClient.UserControls;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public abstract class WindowService : IWindowService
{
    private readonly IAbstractFactory<DialogWindow> _dialogAbstractFactory;

    protected WindowService(IAbstractFactory<DialogWindow> dialogAbstractFactory)
    {
        _dialogAbstractFactory = dialogAbstractFactory;
    }

    public virtual void ShowDialog(object viewModel)
    {
        var shellWindow = _dialogAbstractFactory.Create();
        shellWindow.Content = CreateContent(viewModel);

        shellWindow.ShowDialog();
    }

    public abstract FrameworkElement CreateContent(object viewModel);
}