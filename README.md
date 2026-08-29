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

- `IsPortBusy()` - Returns `true` when the port appears among the machine's active TCP listeners.
- `GetFreePort()` - Temporarily binds loopback port zero and returns the OS-assigned available port.
