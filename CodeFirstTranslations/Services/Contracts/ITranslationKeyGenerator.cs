using System;
using CodeFirstTranslations.Reflection;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
{
    public interface ITranslationKeyGenerator
    {
        /// <summary>
        /// Generates translation key for a code member
        /// </summary>
        /// <param name="codeMember"></param>
        /// <returns></returns>
        [NotNull]
        string GenerateTranslationKey([NotNull] ICodeMemberInfo codeMember);
        [NotNull]
        string GenerateTranslationTypePath([NotNull] Type type);
        [NotNull]
        string GenerateTranslationMemberPath([NotNull] ICodeMemberInfo codeMember);
    }
}