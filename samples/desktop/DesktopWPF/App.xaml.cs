using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.InteropServices;
using Serilog;
using Serilog.Core;
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

        public static Serilog.ILogger Logger { get; private set; }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool AllocConsole();


        public App()
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
            var configuration = BuildAppConfigurationRoot(environmentName);
            var openConsoleInDebugMode = configuration.GetValue<bool>("ApplicationSettings:OpenConsoleInDebugMode");

            Logger = CreateLoggerSerilog(configuration);

            var builder = AddRequiredAppServices();
            AppHost = builder.Build();


#if DEBUG
            if (openConsoleInDebugMode)
            {
                AllocConsole();
                Logger.Information("Console opened: Debug configuration / Development mode");
            }
#endif
        }

        private static IHostBuilder AddRequiredAppServices()
        {
            var builder = Host.CreateDefaultBuilder();
            builder.ConfigureServices(services =>
            {
                services.AddSerilog();
                services.AddSingleton<MainWindow>();

                services.AddTicTacToeApplication();
                services.AddTicTacToePresentation();
                services.AddTicTacToeInfrastructure();
            });
            return builder;
        }

        private static IConfigurationRoot BuildAppConfigurationRoot(string environmentName)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
                .Build();
            return configuration;
        }

        private static Logger CreateLoggerSerilog(IConfigurationRoot configuration)
        {
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            return logger;
        }



        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                Logger.Information("TicTacToe DesktopWPF ist starting!");
                AppHost!.StartAsync();
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex, "TicTacToe DesktopWPF failed to start correctly.");
            }
            finally
            {
                Log.CloseAndFlush();
            }


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
