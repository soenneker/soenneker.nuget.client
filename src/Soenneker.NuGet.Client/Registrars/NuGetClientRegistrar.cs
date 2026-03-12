using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.NuGet.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.NuGet.Client.Registrars;

/// <summary>
/// An async thread-safe HTTP client for the NuGet API
/// </summary>
public static class NuGetClientRegistrar
{
    /// <summary>
    /// Adds <see cref="INuGetClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddNuGetClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton().TryAddSingleton<INuGetClient, NuGetClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="INuGetClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddNuGetClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton().TryAddScoped<INuGetClient, NuGetClient>();

        return services;
    }
}