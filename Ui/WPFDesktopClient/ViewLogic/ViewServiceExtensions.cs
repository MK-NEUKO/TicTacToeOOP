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
        //services.AddTransient<GameOverDialogControl>();
        services.AddAbstractFactory<DialogWindow>();
        services.AddAbstractFactory<GameOverDialogControl>();
    }

    private static void AddAbstractFactory<T>(this IServiceCollection services)
        where T : class
    {
        services.AddTransient<T>();
        services.AddSingleton<Func<T>>(x => () => x.GetService<T>()!);
        services.AddSingleton<IAbstractFactory<T>, AbstractFactory<T>>();
    }
}