using MichaelKoch.TicTacToe.Ui.ViewModel;
using MichaelKoch.TicTacToe.Ui.ViewModel.Contract;
using MichaelKoch.TicTacToe.Ui.ViewModel.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace MichaelKoch.TicTacToe.Mappings;

public static class ServiceExtensions
{
    public static void AddTicTacToeViewModel(this IServiceCollection services)
    {
        services.AddSingleton<IPlayerGameBoardViewModel, PlayerGameBoardViewModel>();
        //services.AddTransient<IPlayerGameBoardAreaViewModel, PlayerGameBoardAreaViewModel>();
        //services.AddTransient<IPlayerViewModel, PlayerViewModel>();
        //services.AddSingleton<IAbstractFactory<IPlayerGameBoardAreaViewModel>, AbstractFactory<IPlayerGameBoardAreaViewModel>>();
        //services.AddSingleton<Func<IPlayerGameBoardAreaViewModel>>(x => ()=> x.GetService<IPlayerGameBoardAreaViewModel>()!);
        //services.AddSingleton<IAbstractFactory<IPlayerViewModel>, AbstractFactory<IPlayerViewModel>>();
        //services.AddSingleton<Func<IPlayerViewModel>>(x => () => x.GetService<IPlayerViewModel>()!);
        services.AddSingleton<IGameViewModel, GameViewModel>();
        services.AddSingleton<IGameMenuViewModel, GameMenuViewModel>();
        services.AddSingleton<IMenuViewModel, MenuViewModel>();
        services.AddSingleton<IMainViewModel, MainViewModel>();
        services.AddViewModelFactory<IPlayerViewModel, PlayerViewModel>();
        services.AddViewModelFactory<IPlayerGameBoardAreaViewModel, PlayerGameBoardAreaViewModel>();
    }

    private static void AddViewModelFactory<TInterface, TImplementation>(this IServiceCollection services)
    where TInterface : class
    where TImplementation : class, TInterface
    {
        services.AddTransient<TInterface, TImplementation>();
        services.AddSingleton<Func<TInterface>>(x => () => x.GetService<TInterface>()!);
        services.AddSingleton<IAbstractFactory<TInterface>, AbstractFactory<TInterface>>();
    }
}