using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    /// <summary>
    /// Translations context
    /// </summary>
    public interface IReadOnlyTranslationContext
    {
        /// <summary>
        /// Translations environment
        /// </summary>
        [NotNull]
        ITranslationsEnvironment Environment { get; }
        /// <summary>
        /// A current culture used for translations
        /// </summary>
        [NotNull]
        string CurrentCulture { get; }
    }
}