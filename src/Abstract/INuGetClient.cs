using System;

namespace Soenneker.NuGet.Client.Abstract;

/// <summary>
/// An async thread-safe HTTP client for the NuGet API
/// </summary>
public interface INuGetClient : IDisposable, IAsyncDisposable
{
}