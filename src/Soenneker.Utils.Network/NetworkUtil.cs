using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Enumerable;
using Soenneker.Utils.Network.Abstract;

namespace Soenneker.Utils.Network;

///<inheritdoc cref="INetworkUtil"/>
public sealed class NetworkUtil : INetworkUtil
{
    private readonly ILogger<NetworkUtil> _logger;

    public NetworkUtil(ILogger<NetworkUtil> logger)
    {
        _logger = logger;
    }

    // TODO: Handle logging here, prob not necessary
    [Pure]
    public bool IsPortBusy(int port)
    {
        var ipGp = IPGlobalProperties.GetIPGlobalProperties();
        IPEndPoint[] endpoints = ipGp.GetActiveTcpListeners();

        if (endpoints.IsNullOrEmpty())
        {
            _logger.LogDebug("{port} port is not busy", port);
            return false;
        }

        if (endpoints.Any(endpoint => endpoint.Port == port))
        {
            _logger.LogDebug("{port} port IS busy", port);
            return true;
        }

        _logger.LogDebug("{port} port is not busy", port);
        return false;
    }
}