using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine
{
    public static class ListEx
    {
        public static T GetRandom<T>(this List<T> list)
        {
            if (list == null || list.Count == 0)
                return default;

            return list[Random.Range(0, list.Count)];
        }

        public static T GetRandomWithOut<T>(this List<T> list, T item)
        {
            if (list == null || list.Count == 0)
                return default;
            if (list.Count == 1)
                return list[0];

            list.Remove(item);
            return list[Random.Range(0, list.Count)];
        }
    }
}

