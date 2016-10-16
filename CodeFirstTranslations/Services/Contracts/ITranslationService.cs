using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
{
    /// <summary>
    /// Translation services is reponsible for translating strings by key. 
    /// </summary>
    public interface ITranslationService
    {
        /// <summary>
        /// Translates a string with the given key 
        /// to the current culture from context. 
        /// Returns fallback if no translation found. 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        [CanBeNull]
        string Translate([NotNull] string key, [CanBeNull] string fallback);
    }
}