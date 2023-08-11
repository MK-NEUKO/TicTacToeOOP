﻿using System.Windows;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.WPFDesktopClient.ViewLogic;
using MichaelKoch.TicTacToe.Mappings;

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
                    services.AddViewLogic();
                    services.AddTicTacToeViewModel();

                    services.AddSingleton<IGameEvaluator, GameEvaluator>();
                    services.AddSingleton<IMinimaxAlgorithm, MinimaxAlgorithm>();
                    services.AddSingleton<ISaveGameManager, SaveGameManager>();

                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.StartAsync();

            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.DataContext = AppHost.Services.GetService<IMainViewModel>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            var gameViewModel = AppHost.Services.GetService<IGameViewModel>();
            gameViewModel.SaveGame();
            await AppHost!.StopAsync();

            base.OnExit(e);
        }
    }
}
