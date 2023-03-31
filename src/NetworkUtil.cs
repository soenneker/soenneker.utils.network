using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Logging;
using Soenneker.Utils.Network.Abstract;

namespace Soenneker.Utils.Network;

///<inheritdoc cref="INetworkUtil"/>
public class NetworkUtil : INetworkUtil
{
    private readonly ILogger<NetworkUtil> _logger;

    public NetworkUtil(ILogger<NetworkUtil> logger)
    {
        _logger = logger;
    }

    [Pure]
    public bool IsPortBusy(int port)
    {
        var ipGp = IPGlobalProperties.GetIPGlobalProperties();
        IPEndPoint[] endpoints = ipGp.GetActiveTcpListeners();

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (endpoints == null || endpoints.Length == 0)
        {
            _logger.LogInformation("{port} port is not busy", port);
            return false;
        }

        if (endpoints.Any(endpoint => endpoint.Port == port))
        {
            _logger.LogInformation("{port} port IS busy", port);
            return true;
        }

        _logger.LogInformation("{port} port is not busy", port);
        return false;
    }
}