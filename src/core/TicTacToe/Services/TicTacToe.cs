using MichaelKoch.TicTacToe.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MichaelKoch.TicTacToe.Core.Services;

public static class TicTacToe
{
    private static IServiceProvider? _internalServiceProvider;

    public static IGameService GetGameService()
    {
        if (_internalServiceProvider != null) return _internalServiceProvider.GetRequiredService<IGameService>();
        CreateServicesInternal();
        if(_internalServiceProvider == null) throw new Exception("Service provider is null");
        return _internalServiceProvider.GetRequiredService<IGameService>();
    }

    public static IPlayerService GetPlayerService()
    {
        if (_internalServiceProvider != null) return _internalServiceProvider.GetRequiredService<IPlayerService>();
        CreateServicesInternal();
        if(_internalServiceProvider == null) throw new Exception("Service provider is null");
        return _internalServiceProvider.GetRequiredService<IPlayerService>();
    }

    private static void CreateServicesInternal()
    {
        var services = new ServiceCollection();
        AddServices(services); 
        _internalServiceProvider = services.BuildServiceProvider();
    }

    public static void AddServices(IServiceCollection services)
    {
        services.AddSingleton<IGameService, GameService>();
        services.AddSingleton<IPlayerService, PlayerService>();
    }
}