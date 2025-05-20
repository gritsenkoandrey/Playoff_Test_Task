using System;
using System.Collections.Generic;

namespace Runtime.Utils.Extensions
{
    public static class CollectionExtension
    {
        public static void Foreach<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (T element in collection) action.Invoke(element);
        }
        
        public static void Shuffle<T>(this IList<T> collection)
        {
            for (int i = collection.Count - 1; i > 0; i--)
            {
                int randomIndex = UnityEngine.Random.Range(0, i + 1);
                (collection[i], collection[randomIndex]) = (collection[randomIndex], collection[i]);
            }
        }
    }
}