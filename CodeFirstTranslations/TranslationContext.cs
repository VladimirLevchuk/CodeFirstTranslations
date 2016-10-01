using System;

namespace CodeFirstTranslations
{
    public class TranslationContext
    {
        public static IReadOnlyTranslationContext DefaultContext { get; set; }
        public static Func<IReadOnlyTranslationContext> ContextAccessor = () => DefaultContext;
        public static IReadOnlyTranslationContext Current => ContextAccessor();
    }
}