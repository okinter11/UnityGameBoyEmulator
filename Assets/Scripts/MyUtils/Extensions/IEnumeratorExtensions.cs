using System.Collections;

namespace MyUtils.Extensions
{
    public static class IEnumeratorExtensions
    {
        /// <summary>
        ///     协程执行到结束
        /// </summary>
        public static void RunToEnd(this IEnumerator enumerator)
        {
            while (enumerator.MoveNext())
            {
                // do nothing
            }
        }
    }
}