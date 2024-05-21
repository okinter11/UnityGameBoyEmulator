using UnityEngine;

namespace MyUtils.Extensions
{
    public static class BoundsExtensions
    {
        public static bool Contains(this Bounds bounds, Bounds other) =>
            bounds.Contains(other.min) && bounds.Contains(other.max);
    }
}