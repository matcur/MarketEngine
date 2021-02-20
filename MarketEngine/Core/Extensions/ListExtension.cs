using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketEngine.Core.Extensions
{
    public static class ListExtension
    {
        public static List<TOut> Map<TIn, TOut>(this IEnumerable<TIn> source, Func<TIn, TOut> func)
        {
            var result = new List<TOut>();
            foreach (var item in source)
                result.Add(func.Invoke(item));

            return result;
        }
    }
}
