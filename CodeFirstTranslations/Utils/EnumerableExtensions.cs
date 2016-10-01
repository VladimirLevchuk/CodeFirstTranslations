using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    public static class EnumerableExtensions
    {
        [NotNull]
        public static IEnumerable<T> OrEmpty<T>([CanBeNull] this IEnumerable<T> enumerable)
        {
            return enumerable ?? Enumerable.Empty<T>();
        } 
    }
}