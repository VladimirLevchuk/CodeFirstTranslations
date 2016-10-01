using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    /// <summary>
    /// Path util
    /// </summary>
    public interface IPathUtil
    {
        /// <summary>
        /// Separates path segments,
        /// i.e. "/" in path "/parent/child"
        /// </summary>
        [NotNull]
        string PathSeparator { get; }
        /// <summary>
        /// Combines 2 path segments using PathSeparator
        /// </summary>
        /// <param name="path1"></param>
        /// <param name="path2"></param>
        /// <returns></returns>
        [NotNull]
        string Combine([NotNull] string path1, [NotNull] string path2);
        /// <summary>
        /// Converts path to a key (to be passed to TranslationService). 
        /// Default implementation converts path to lowercase
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        [NotNull]
        string MakeKey([NotNull] string path);
    }
}