﻿using MichaelKoch.TicTacToe.Data.DataStoring;
using MichaelKoch.TicTacToe.Data.DataStoring.Contract;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore;
using MichaelKoch.TicTacToe.Logic.TicTacToeCore.Contract;
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
        services.AddSingleton<IGameViewModel, GameViewModel>();
        services.AddSingleton<IGameInfoBoardViewModel, GameInfoBoardViewModel>();
        services.AddSingleton<IGameMenuViewModel, GameMenuViewModel>();
        services.AddSingleton<IMenuViewModel, MenuViewModel>();
        services.AddSingleton<IMainViewModel, MainViewModel>();
        services.AddViewModelFactory<IPlayerViewModel, PlayerViewModel>();
        services.AddViewModelFactory<IPlayerGameBoardAreaViewModel, PlayerGameBoardAreaViewModel>();
        services.AddViewModelFactory<IGameOverDialogViewModel, GameOverDialogViewModel>();
        services.AddViewModelFactory<IGetSecureQueryDialogViewModel, GetSecureQueryDialogViewModel>();
    }

    private static void AddViewModelFactory<TInterface, TImplementation>(this IServiceCollection services)
    where TInterface : class
    where TImplementation : class, TInterface
    {
        services.AddTransient<TInterface, TImplementation>();
        services.AddSingleton<Func<TInterface>>(x => () => x.GetService<TInterface>()!);
        services.AddSingleton<IViewModelFactory<TInterface>, ViewModelFactory<TInterface>>();
    }

    public static void AddTicTacToeLogic(this IServiceCollection services)
    {
        services.AddSingleton<IGameEvaluator, GameEvaluator>();
        services.AddSingleton<IMinimaxAlgorithm, MinimaxAlgorithm>();
        services.AddSingleton<ISaveGameManager, SaveGameManager>();
    }

    public static void AddTicTacToeData(this IServiceCollection services)
    {
        services.AddSingleton<ISaveGameRepository, SaveGameRepository>();
    }
}