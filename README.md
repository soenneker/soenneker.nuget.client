# Soenneker.NuGet.Client
[![](https://img.shields.io/nuget/v/soenneker.nuget.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.nuget.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.nuget.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.nuget.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.nuget.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.nuget.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.nuget.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.nuget.client/actions/workflows/codeql.yml)

Provides a dependency-injected accessor for a shared `HttpClient` used by NuGet protocol code.

## Installation

```bash
dotnet add package Soenneker.NuGet.Client
```

## Registration

```csharp
using Soenneker.NuGet.Client.Registrars;

builder.Services.AddNuGetClientAsScoped();
// or: builder.Services.AddNuGetClientAsSingleton();
```

Both registrations keep the underlying HTTP client cache singleton. A scoped accessor can be disposed at the end of its scope without removing or disposing the shared client.

## Usage

```csharp
using Soenneker.NuGet.Client.Abstract;

HttpClient client = await nugetClient.Get(cancellationToken);

using HttpResponseMessage response = await client.GetAsync(
    "https://api.nuget.org/v3/index.json",
    cancellationToken);

response.EnsureSuccessStatusCode();
string serviceIndex = await response.Content.ReadAsStringAsync(cancellationToken);
```

Do not dispose the `HttpClient` returned by `Get`; it is shared and owned by the singleton cache. Dispose request and response messages created by the calling code.

This package does not set a base address, implement NuGet service-index discovery, serialize protocol models, add authentication, retry requests, or validate source URLs. Use absolute request URIs and apply explicit timeouts and retry policy where the operation requires them. If package-source URLs can come from users or tenants, constrain them to approved HTTPS hosts to avoid server-side request forgery.

For higher-level search, version, catalog, dependency, and publishing operations, use `Soenneker.Utils.NuGet`, which consumes this client.
