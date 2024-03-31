using System;
using System.Net.Http;
using System.Threading.Tasks;
using Soenneker.NuGet.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.NuGet.Client;

/// <inheritdoc cref="INuGetClient"/>
public class NuGetClient : INuGetClient
{
    private readonly IHttpClientCache _httpClientCache;

    public NuGetClient(IHttpClientCache httpClientCache)
    {
        _httpClientCache = httpClientCache;
    }

    public ValueTask<HttpClient> Get()
    {
        return _httpClientCache.Get(nameof(NuGetClient));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _httpClientCache.RemoveSync(nameof(NuGetClient));
    }

    public ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        return _httpClientCache.Remove(nameof(NuGetClient));
    }
}