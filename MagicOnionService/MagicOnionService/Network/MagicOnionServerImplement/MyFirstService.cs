using MagicOnion;
using MagicOnion.Server;
using MagicOnionService.Network.MagicOnionServer;
using Microsoft.AspNetCore.Mvc;

namespace MagicOnionService.Network.MagicOnionServerImplement;

// Implements RPC service in the server project.
// The implementation class must inherit `ServiceBase<IMyFirstService>` and `IMyFirstService`
public class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService
{
    // `UnaryResult<T>` allows the method to be treated as `async` method.
    public async UnaryResult<int> SumAsync(int x, int y)
    {
        return x + y;
    }
}