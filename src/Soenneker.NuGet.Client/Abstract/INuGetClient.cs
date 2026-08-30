using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.NuGet.Client.Abstract;

/// <summary>
/// Provides access to a shared HTTP client used for NuGet protocol requests.
/// </summary>
public interface INuGetClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the shared HTTP client used for NuGet protocol requests.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the shared HTTP client. The caller must not dispose it.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
