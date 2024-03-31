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
    public static void AddNuGetClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddSingleton<INuGetClient, NuGetClient>();
    }

    /// <summary>
    /// Adds <see cref="INuGetClient"/> as a scoped service. <para/>
    /// </summary>
    public static void AddNuGetClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddScoped<INuGetClient, NuGetClient>();
    }
}
