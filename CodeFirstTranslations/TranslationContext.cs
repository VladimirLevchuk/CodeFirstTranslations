using System;
using CodeFirstTranslations.Translations;
using CodeFirstTranslations.Utils;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    public class TranslationContext
    {
        public static IReadOnlyTranslationContext DefaultContext { get; set; }
        public static Func<IReadOnlyTranslationContext> ContextAccessor = () => DefaultContext;

        [NotNull]
        public static IReadOnlyTranslationContext Current
        {
            get
            {
                var result = ContextAccessor?.Invoke();
                if (result == null)
                {
                    throw new CodeFirstTranslationsException(ErrorMessages.NoContext.ToString());
                }
                return result;
            }
        }
    }
}