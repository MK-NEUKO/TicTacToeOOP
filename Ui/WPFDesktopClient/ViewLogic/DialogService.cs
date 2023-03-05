using System;
using System.Windows;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.WPFDesktopClient.UserControls;
using Microsoft.Extensions.Hosting;
using MichaelKoch.TicTacToe.Ui.WPFDesktopClient;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public class DialogService : IDialogService
{
    public void ShowDialog<TViewModel>()
    {
        var dialog = new DialogWindow();
        
        var content = Activator.CreateInstance<GameOverDialog>();
        var vm = Activator.CreateInstance<TViewModel>();
        content.DataContext = vm;
        dialog.Content = content;
        dialog.Owner = (Window)App.AppHost!.Services.GetService(typeof(MainWindow))!;

        

        dialog.ShowDialog();
    }
}