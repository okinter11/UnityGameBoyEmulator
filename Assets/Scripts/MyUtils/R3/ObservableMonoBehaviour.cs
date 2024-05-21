using System;
using R3;
using UnityEngine;

namespace MyUtils.R3
{
    /// <summary>
    ///     观察者模式的MonoBehaviour
    /// </summary>
    public class ObservableMonoBehaviour : MonoBehaviour
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