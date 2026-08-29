using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.NuGet.Client.Abstract;

/// <summary>
/// An async thread-safe HTTP client for the NuGet API
/// </summary>
public interface INuGetClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured http Client used by the nu get client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested http Client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
