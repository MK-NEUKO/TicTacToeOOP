using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using TicTacToe.Application;
using TicTacToe.Infrastructure;
using TicTacToe.Presentation;

namespace MichaelKoch.TicTacToe.Samples.DesktopWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            var builder = Host.CreateDefaultBuilder();
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>();

                services.AddTicTacToeApplication();
                services.AddTicTacToePresentation();
                services.AddTicTacToeInfrastructure();
            });

            AppHost = builder.Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            AppHost!.StartAsync();
            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            //var gameViewModel = AppHost.Services.GetRequiredService<GameViewModel>();
            

            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            AppHost!.StopAsync();
            base.OnExit(e);
        }
    }

}
