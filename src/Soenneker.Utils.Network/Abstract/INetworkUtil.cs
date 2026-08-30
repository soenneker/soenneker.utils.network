using System.Diagnostics.Contracts;

namespace Soenneker.Utils.Network.Abstract;

/// <summary>
/// A utility library of helpful network related operations
/// </summary>
public interface INetworkUtil
{
    /// <summary>
    /// Determines whether a TCP port appears in the operating system's current local-listener snapshot.
    /// </summary>
    /// <param name="port">The TCP port number.</param>
    /// <returns>True when a listener uses the port.</returns>
    [Pure]
    bool IsPortBusy(int port);

    /// <summary>
    /// Temporarily binds IPv4 loopback port zero and returns the operating system-assigned TCP port after releasing it.
    /// </summary>
    /// <returns>A port that was available for the temporary loopback listener.</returns>
    int GetFreePort();
}
