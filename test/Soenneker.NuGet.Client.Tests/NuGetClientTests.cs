using Soenneker.NuGet.Client.Abstract;
using Soenneker.Tests.HostedUnit;


namespace Soenneker.NuGet.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class NuGetClientTests : HostedUnitTest
{
    private readonly INuGetClient _util;

    public NuGetClientTests(Host host) : base(host)
    {
        _util = Resolve<INuGetClient>(true);
    }

    [Test]
    public void Default()
    {
    }
}