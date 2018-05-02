namespace NeuralNet
{
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static void ForEach<TElem>(this IEnumerable<TElem> source, Action<TElem> action)
        {
            foreach (var element in source)
            {
                action(element);
            }
        }
    }
}