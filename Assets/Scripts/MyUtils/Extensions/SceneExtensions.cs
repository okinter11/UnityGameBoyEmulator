using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyUtils.Extensions
{
    public static class SceneExtensions
    {
        public static List<T> GetAll<T>(this Scene scene) where T : Object
        {
            List<T> results = new();
            GameObject[] rootGameObjects = scene.GetRootGameObjects();
            foreach (GameObject go in rootGameObjects)
            {
                results.AddRange(go.GetComponentsInChildren<T>());
            }

            return results;
        }
    }
}