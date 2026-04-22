using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Utils.Network.Abstract;
using Soenneker.Tests.HostedUnit;


namespace Soenneker.Utils.Network.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class NetworkUtilTests : HostedUnitTest
{
    private readonly INetworkUtil _util;

    public NetworkUtilTests(Host host) : base(host)
    {
        _util = Resolve<INetworkUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
