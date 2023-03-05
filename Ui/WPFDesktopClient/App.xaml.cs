﻿using System;
using System.ComponentModel;
using System.Windows;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Factories;
using MichaelKoch.TicTacToe.Ui.ViewModel.Helper;
using MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;

namespace MichaelKoch.TicTacToe.Ui.WPFDesktopClient
{
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IGameEvaluator, GameEvaluator>();

                    services.AddTransient<IDialogService, DialogService>();
                    services.AddSingleton<IPlayerFactory, PlayerFactory>();
                    services.AddSingleton<IPlayerGameBoardViewModel, PlayerGameBoardViewModel>();
                    services.AddTransient<IPlayerGameBoardAreaViewModel, PlayerGameBoardAreaViewModel>();
                    services.AddSingleton<IAbstractFactory<IPlayerGameBoardAreaViewModel>, AbstractFactory<IPlayerGameBoardAreaViewModel>>();
                    services.AddSingleton<Func<IPlayerGameBoardAreaViewModel>>(x => ()=> x.GetService<IPlayerGameBoardAreaViewModel>()!);
                    services.AddSingleton<IGameViewModel, GameViewModel>();
                    services.AddSingleton<IGameMenuViewModel, GameMenuViewModel>();
                    services.AddSingleton<IMenuViewModel, MenuViewModel>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.DataContext = AppHost.Services.GetService<MainViewModel>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();

            base.OnExit(e);
        }
    }
}
