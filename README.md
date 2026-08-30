[![](https://img.shields.io/nuget/v/Soenneker.Utils.Network.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.Network/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.network/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.utils.network/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.Utils.Network.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.Utils.Network/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.utils.network/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.utils.network/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Utils.Network
A utility library of helpful network related operations.

## Installation

```bash
dotnet add package Soenneker.Utils.Network
```

## Quick start

```csharp
using Soenneker.Utils.Network.Registrars;

services.AddNetworkUtilAsSingleton();
```

Then inject `INetworkUtil` wherever you need it.

## Common operations

```csharp
if (networkUtil.IsPortBusy(5000))
{
    // A local TCP listener was present in the snapshot.
}

int candidatePort = networkUtil.GetFreePort();
```

`IsPortBusy` compares the requested number with the operating system's active TCP listener
snapshot. It does not test UDP, remote hosts, firewall reachability, or whether the current process
can bind a particular address. The result can change immediately after the call.

`GetFreePort` asks the operating system to bind port zero on IPv4 loopback, reads the assigned port,
then closes the listener before returning. The returned number is therefore a candidate, not a
reservation: another thread or process can claim it before the caller binds. For reliable server
startup, bind port zero on the actual server listener and keep that listener open instead of using
a check-then-bind sequence.

Both methods can surface socket or operating-system errors. The utility contains no mutable
network state, so scoped and singleton registration are both available; choose the lifetime needed
by its consumers.
