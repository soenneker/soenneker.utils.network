using System.Diagnostics.Contracts;

namespace Soenneker.Utils.Network.Abstract;

/// <summary>
/// A utility library of helpful network related operations
/// </summary>
public interface INetworkUtil
{
    /// <summary>
    /// Determines whether a TCP port is currently bound by a local listener.
    /// </summary>
    /// <param name="port">The TCP port number.</param>
    /// <returns>True when a listener uses the port.</returns>
    [Pure]
    bool IsPortBusy(int port);

    /// <summary>
    /// Asks the operating system for an available ephemeral TCP port.
    /// </summary>
    /// <returns>An available ephemeral port.</returns>
    int GetFreePort();
}