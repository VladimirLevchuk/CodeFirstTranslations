using System;
using CodeFirstTranslations.Reflection;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
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
        [NotNull]
        string GetTranslationTypePath([NotNull] Type type);
        [NotNull]
        string GetTranslationMemberPath([NotNull] ICodeMemberInfo codeMember);
    }
}