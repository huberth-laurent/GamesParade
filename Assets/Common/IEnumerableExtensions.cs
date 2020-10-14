﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Common
{
    static class IEnumerableExtensions
    {
        public static T MaxBy<T>(this IEnumerable<T> sequence, Func<T, float> selector)
            => sequence.Aggregate((element: sequence.First(), value: selector(sequence.First())),
                (a, b) =>
                {
                    var bValue = selector(b);
                    return a.value > bValue ? a : (b, bValue);
                }).element;
    }
}
