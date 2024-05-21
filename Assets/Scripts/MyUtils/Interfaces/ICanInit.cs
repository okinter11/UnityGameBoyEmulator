using System.Collections;

namespace MyUtils.Interfaces
{
    /// <summary>
    ///     可初始化的接口
    /// </summary>
    public interface ICanInit
    {
        /// <summary>
        ///     是否已经初始化
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        ///     初始化方法
        /// </summary>
        IEnumerator Init();
    }
}