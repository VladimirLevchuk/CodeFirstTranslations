using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
{
    public interface ITranslationKeyInitializer
    {
        void AutoGenerateMissedKeys([NotNull] ITranslationTypesRegistry translationTypesRegistry);
    }
}