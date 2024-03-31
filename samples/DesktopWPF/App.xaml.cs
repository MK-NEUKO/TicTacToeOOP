using System.Windows;
using MichaelKoch.TicTacToe.Core.Interfaces;
using MichaelKoch.TicTacToe.Core.Services;
using MichaelKoch.TicTacToe.Samples.ViewModel;
using MichaelKoch.TicTacToe.Samples.ViewModel.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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

                services.AddSingleton<IPlayerService, PlayerService>();

                services.AddTransient<IPlayer, PlayerViewModel>();
                services.AddSingleton<IGameInfoBoardViewModel, GameInfoBoardViewModel>();
            });

            AppHost = builder.Build();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            AppHost!.StartAsync();
            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();

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
