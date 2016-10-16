using System.Collections.Generic;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    /// <summary>
    /// Code first translation property
    /// with key auto-generated from call stack. 
    /// Made abstract. For typed translations use TranslationField instead for performance reasons. 
    /// For string properties (used for validation) use StringTranslationProperty
    /// </summary>
    public abstract class TranslationProperty : Translation
    {
        protected TranslationProperty([NotNull] string text, [NotNull] string key, [CanBeNull] IEnumerable<string> alternativeKeys = null) : base(text, key, alternativeKeys)
        {
        }

        public TranslationProperty([NotNull] string text, [CanBeNull] IEnumerable<string> alternativeKeys)
            : this(text,
                TranslationContext.Current.Environment.TranslationKeySpy.GenerateTranslationKeyFromCallStack(),
                alternativeKeys)
        {
        }

        public TranslationProperty([NotNull] string text)
            : this(text, TranslationContext.Current.Environment.TranslationKeySpy.GenerateTranslationKeyFromCallStack())
        {
        }
    }
}