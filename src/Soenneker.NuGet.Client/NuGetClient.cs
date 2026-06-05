using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.NuGet.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.NuGet.Client;

/// <inheritdoc cref="INuGetClient"/>
public sealed class NuGetClient : INuGetClient
{
    private readonly IHttpClientCache _httpClientCache;

    public NuGetClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default)
    {
        return _httpClientCache.Get(nameof(NuGetClient), cancellationToken: cancellationToken);
    }

    /// <summary>
    /// Releases resources used by the current instance.
    /// </summary>
    public void Dispose()
    {
        _httpClientCache.RemoveSync(nameof(NuGetClient));
    }

    /// <summary>
    /// Asynchronously releases resources used by the current instance.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public ValueTask DisposeAsync()
    {
        return _httpClientCache.Remove(nameof(NuGetClient));
    }
}