using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Utils.Network.Abstract;

namespace Soenneker.Utils.Network.Registrars;

public static class NetworkUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="INetworkUtil"/> as a scoped service. (Recommended) <para/>
    /// </summary>
    public static IServiceCollection AddNetworkUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<INetworkUtil, NetworkUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="INetworkUtil"/> as a singleton service. <para/>
    /// (Use <see cref="AddNetworkUtilAsScoped"/> unless this is being consumed by a Singleton)
    /// </summary>
    public static IServiceCollection AddNetworkUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<INetworkUtil, NetworkUtil>();

        return services;
    }
}