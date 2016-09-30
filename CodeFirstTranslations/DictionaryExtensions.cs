using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Creuna.CodeFirstTranslations2
{
    public static class DictionaryExtensions
    {
        public static TValue TryGetValue<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> dictionary, 
            [NotNull] TKey key, TValue fallback = default(TValue))
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));
            if (key == null) throw new ArgumentNullException(nameof(key));

            TValue result;
            return dictionary.TryGetValue(key, out result) ? result : fallback;
        }
    }
}