using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    public interface ITranslationKeyBuilder
    {
        /// <summary>
        /// Builds translation key for a code member
        /// </summary>
        /// <param name="codeMember"></param>
        /// <returns></returns>
        [NotNull]
        string BuildTranslationKey([NotNull] ICodeMemberInfo codeMember);
    }
}