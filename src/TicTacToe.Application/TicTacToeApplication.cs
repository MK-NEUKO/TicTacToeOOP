using Microsoft.Extensions.DependencyInjection;

namespace TicTacToe.Application;

public static class TicTacToeApplication
{
    public static IServiceCollection AddTicTacToeApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssemblies(
                typeof(TicTacToeApplication).Assembly));


        return services;
    }
}