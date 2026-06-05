using System.Diagnostics.Contracts;

namespace Soenneker.Utils.Network.Abstract;

/// <summary>
/// A utility library of helpful network related operations
/// </summary>
public interface INetworkUtil
{
    /// <summary>
    /// Executes the is port busy operation.
    /// </summary>
    /// <param name="port">The port.</param>
    /// <returns>A value indicating whether the operation succeeded.</returns>
    [Pure]
    bool IsPortBusy(int port);

    /// <summary>
    /// Gets free port.
    /// </summary>
    /// <returns>The result of the operation.</returns>
    int GetFreePort();
}