using System;
using Microsoft.Extensions.DependencyInjection;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.WPFDesktopClient.UserControls;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

public static class ViewServiceExtensions
{
    public static void AddViewLogic(this IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<Func<MainWindow>>(x => () => x.GetService<MainWindow>()!);
        services.AddSingleton<IWindowService<IGameOverDialogViewModel>, GameOverDialog>();
        services.AddSingleton<IWindowService<IGetSecureQueryDialogViewModel>, GetSecureQueryDialog>();
        services.AddAbstractFactory<DialogWindow>();
        services.AddAbstractFactory<GameOverDialogControl>();
        services.AddAbstractFactory<GetSecureDialogControl>();
    }

    private static void AddAbstractFactory<T>(this IServiceCollection services)
        where T : class
    {
        services.AddTransient<T>();
        services.AddSingleton<Func<T>>(x => () => x.GetService<T>()!);
        services.AddSingleton<IAbstractFactory<T>, AbstractFactory<T>>();
    }
}