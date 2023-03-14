using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Windows;
using MichaelKoch.TicTacToe.Ui.ViewModel;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.WPFDesktopClient.UserControls;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public abstract class WindowService : IWindowService
{
    public virtual void ShowDialog(object viewModel)
    {
        var shellWindow = new DialogWindow();
        shellWindow.Content = CreateContent();

        shellWindow.ShowDialog();
    }

    public abstract FrameworkElement CreateContent();
}