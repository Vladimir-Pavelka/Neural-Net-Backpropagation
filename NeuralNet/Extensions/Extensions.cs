namespace Extensions
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (var element in source)
            {
                action(element);
            }
        }
    }
}