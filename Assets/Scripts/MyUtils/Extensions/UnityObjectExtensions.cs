using UnityEngine;
using UnityObject = UnityEngine.Object;

namespace MyUtils.Extensions
{
    public static class UnityObjectExtensions
    {
        /// <summary>
        ///     获取GameObject
        /// </summary>
        public static GameObject GameObject(this UnityObject uo)
        {
            if (uo is GameObject go)
            {
                return go;
            }
            else if (uo is Component c)
            {
                return c.gameObject;
            }
            else
            {
                return null;
            }
        }
    }
}