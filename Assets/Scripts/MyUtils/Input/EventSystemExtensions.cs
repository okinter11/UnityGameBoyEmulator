using UnityEngine;
using UnityEngine.EventSystems;

namespace MyUtils.Input
{
    public static class EventSystemExtensions
    {
        /// <summary>
        ///     是否鼠标在窗口上
        /// </summary>
        public static bool IsPointerOverWindow(this EventSystem eventSystem)
        {
            Vector3 mousePosition = UnityEngine.Input.mousePosition;
            return mousePosition.x >= 0
                && mousePosition.x <= Screen.width
                && mousePosition.y >= 0
                && mousePosition.y <= Screen.height;
        }
    }
}