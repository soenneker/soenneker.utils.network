using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Utils.Network.Abstract;

namespace Soenneker.Utils.Network.Registrars;

/// <summary>
/// Represents the network util registrar.
/// </summary>
public static class NetworkUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="INetworkUtil"/> as a scoped service. (Recommended) <para/>
    /// </summary>
    /// <returns>Adds <see cref="INetworkUtil"/> as a scoped service. (Recommended) <para/>.</returns>
    public static IServiceCollection AddNetworkUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<INetworkUtil, NetworkUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="INetworkUtil"/> as a singleton service. <para/>
    /// (Use <see cref="AddNetworkUtilAsScoped"/> unless this is being consumed by a Singleton)
    /// </summary>
    /// <returns>Adds <see cref="INetworkUtil"/> as a singleton service. <para/> (Use <see cref="AddNetworkUtilAsScoped"/> unless this is being consumed by a Singleton).</returns>
    public static IServiceCollection AddNetworkUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<INetworkUtil, NetworkUtil>();

        return services;
    }
}