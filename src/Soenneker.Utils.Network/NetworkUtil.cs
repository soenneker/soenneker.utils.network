using Microsoft.Extensions.Logging;
using Soenneker.Utils.Network.Abstract;
using System.Diagnostics.Contracts;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Soenneker.Utils.Network;

/// <inheritdoc cref="INetworkUtil" />
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

        if (endpoints.Length == 0)
        {
            _logger.LogDebug("{port} port is not busy", port);
            return false;
        }

        for (var i = 0; i < endpoints.Length; i++)
        {
            if (endpoints[i].Port == port)
            {
                _logger.LogDebug("{port} port IS busy", port);
                return true;
            }
        }

        _logger.LogDebug("{port} port is not busy", port);
        return false;
    }

    public int GetFreePort()
    {
        var listener = new TcpListener(IPAddress.Loopback, 0);

        try
        {
            listener.Start();
            return ((IPEndPoint)listener.LocalEndpoint).Port;
        }
        finally
        {
            listener.Stop();
        }
    }
}
