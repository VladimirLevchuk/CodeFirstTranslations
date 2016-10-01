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
        ITranslationsEnvironment Environment { get; }
        /// <summary>
        /// A current culture used for translations
        /// </summary>
        string CurrentCulture { get; }
    }
}