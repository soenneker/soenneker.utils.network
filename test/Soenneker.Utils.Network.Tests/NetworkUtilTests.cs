using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Utils.Network.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Utils.Network.Tests;

[Collection("Collection")]
public class NetworkUtilTests : FixturedUnitTest
{
    private readonly INetworkUtil _util;

    public NetworkUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<INetworkUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
