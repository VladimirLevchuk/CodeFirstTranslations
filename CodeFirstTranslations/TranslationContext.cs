using System;

namespace Creuna.CodeFirstTranslations2
{
    public interface IReadOnlyTranslationContext
    {
        ITranslationsEnvironment Environment { get; }
        string CurrentCulture { get; }
    }

    public interface IWriteOnlyTranslationContext
    {
        string CurrentCulture { set; }
    }

    public class TranslationContext
    {
        public static IReadOnlyTranslationContext DefaultContext { get; set; }
        public static Func<IReadOnlyTranslationContext> ContextAccessor = () => DefaultContext;
        public static IReadOnlyTranslationContext Current => ContextAccessor();
    }
}