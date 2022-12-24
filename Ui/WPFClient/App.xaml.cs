using MichaelKoch.TicTacToe.Logic.TicTacToeCore;
using System;
using System.Windows;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MichaelKoch.TicTacToe.Ui.WPFClient
{
    public partial class App : Application
    { 
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<MainWindow>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost!.RunAsync();

            var startWindow = AppHost!.Services.GetRequiredService<MainWindow>();
            startWindow.Show();

            base.OnStartup(e);
        }


        private static void CreateAreas(IServiceCollection services)
        {
            const int numberOfAreas = 9;
            for (int i = 0; i < numberOfAreas; i++)
            {
                services.AddSingleton<IPlayerGameBoardAreaViewModel>(new PlayerGameBoardAreaViewModel(i));
            }
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost!.StopAsync();

            base.OnExit(e);
        }
    }
}
