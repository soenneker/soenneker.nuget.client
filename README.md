[![](https://img.shields.io/nuget/v/soenneker.nuget.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.nuget.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.nuget.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.nuget.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.nuget.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.nuget.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.nuget.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.nuget.client/actions/workflows/codeql.yml)

# Soenneker.NuGet.Client

An async thread-safe HTTP client for the NuGet API.

## Install

```bash
dotnet add package Soenneker.NuGet.Client
```

## Quick start

```csharp
using Soenneker.NuGet.Client.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddNuGetClientAsSingleton();
```

Adds `INuGetClient` as a singleton service.

## What you get

- `INuGetClient` — An async thread-safe HTTP client for the NuGet API.
- `NuGetClientRegistrar` — An async thread-safe HTTP client for the NuGet API.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `NuGetClientRegistrar.AddNuGetClientAsSingleton(services)` | Adds `INuGetClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `NuGetClientRegistrar.AddNuGetClientAsScoped(services)` | Adds `INuGetClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Dispose instances you own when their scope ends so held resources can be released.
