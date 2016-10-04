using CodeFirstTranslations.Reflection;
using CodeFirstTranslations.Services;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    /// <summary>
    /// a pure man DI
    /// </summary>
    public interface ITranslationsEnvironment
    {
        [NotNull]
        ITranslationKeySpy TranslationKeySpy { get; }
        [NotNull]
        ITranslationService TranslationService { get; }
        [NotNull]
        ITranslationTypesRegistry TranslationTypesRegistry { get; }
        [NotNull]
        ITranslationKeyBuilder TranslationKeyBuilder { get; }
        [NotNull]
        ICodeMemberKeyBuilder CodeMemberKeyBuilder { get; }
        [NotNull]
        ICodeMemberInfoFactory CodeMemberInfoFactory { get; }
        [NotNull]
        IEnumTranslationService EnumTranslationService { get; }
        [NotNull]
        IPathUtil PathUtil { get; }
    }
}