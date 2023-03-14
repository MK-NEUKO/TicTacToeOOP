using System;
using System.Collections.Generic;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.WPFDesktopClient.UserControls;
using Microsoft.Extensions.DependencyInjection;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public static class ViewServiceExtensions
{
    public static void AddViewLogic(this IServiceCollection services)
    {
        services.AddSingleton<IWindowService, GameOverDialog>();
        services.AddTransient<DialogWindow>();
        services.AddTransient<GameOverDialogControl>();
    }
}