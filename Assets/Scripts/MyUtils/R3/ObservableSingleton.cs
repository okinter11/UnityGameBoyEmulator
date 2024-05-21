using System;
using R3;

namespace MyUtils.R3
{
    public class ObservableSingleton<T> : Singleton<T> where T : ObservableSingleton<T>
    {
        /// <summary>
        ///     用于释放资源
        /// </summary>
        private IDisposable _disposable;

        /// <summary>
        ///     初始化监控资源
        /// </summary>
        protected virtual void OnEnable()
        {
            DisposableBuilder builder = Disposable.CreateBuilder();
            OnEnableInit(ref builder);
            _disposable = builder.Build();
        }

        /// <summary>
        ///     释放监控资源
        /// </summary>
        protected virtual void OnDisable()
        {
            _disposable?.Dispose();
        }

        /// <summary>
        ///     继承者实现该函数
        /// </summary>
        protected virtual void OnEnableInit(ref DisposableBuilder builder)
        {
            // ignore
        }
    }
}