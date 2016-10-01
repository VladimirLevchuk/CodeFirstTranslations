using System.Collections.Generic;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    /// <summary>
    /// Translation without possibility to auto-generate key
    /// </summary>
    public class TranslationWithKey : Translation
    {
        public TranslationWithKey([NotNull] string text, [NotNull] string key, [CanBeNull] IEnumerable<string> alternativeKeys = null) : base(text, key, alternativeKeys)
        {
        }
    }
}