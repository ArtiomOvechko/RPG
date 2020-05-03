using System;
using System.Collections.Generic;

namespace ArtiomOvechko.RPG.Mono.Core.Extensions
{
    public static class LinqExtension
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
            }
        }
    }
}
