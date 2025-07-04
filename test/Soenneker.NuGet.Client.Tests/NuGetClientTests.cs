using Soenneker.NuGet.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.NuGet.Client.Tests;

[Collection("Collection")]
public class NuGetClientTests : FixturedUnitTest
{
    private readonly INuGetClient _util;

    public NuGetClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<INuGetClient>(true);
    }
}
