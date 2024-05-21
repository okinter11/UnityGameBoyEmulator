using System;
using System.Threading;

namespace MyUtils
{
    /// <summary>
    ///     懒加载
    /// </summary>
    public class ImplicitLazy<T>
    {
        private Lazy<T> _value;

        public T Value => _value.Value;

        public bool IsValueCreated => _value.IsValueCreated;

        public ImplicitLazy(Func<T> valueFactory) => _value = new Lazy<T>(valueFactory);

        public ImplicitLazy(Func<T> valueFactory, LazyThreadSafetyMode mode)
            => _value = new Lazy<T>(valueFactory, mode);

        public static implicit operator T(ImplicitLazy<T> lazy) => lazy._value.Value;

        public static implicit operator bool(ImplicitLazy<T> lazy) => lazy._value.IsValueCreated;

        public override string ToString() => _value.ToString();
    }
}