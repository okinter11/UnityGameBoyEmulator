using MagicOnion;

namespace MagicOnionService.Network.MagicOnionServer
{
    public interface IMyFirstService : IService<IMyFirstService>
    {
        // The return type must be `UnaryResult<T>` or `UnaryResult`.
        public UnaryResult<int> SumAsync(int x, int y);
    }
}