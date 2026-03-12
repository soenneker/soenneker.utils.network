using System.Diagnostics.Contracts;

namespace Soenneker.Utils.Network.Abstract;

/// <summary>
/// A utility library of helpful network related operations
/// </summary>
public interface INetworkUtil
{
    [Pure]
    bool IsPortBusy(int port);
}