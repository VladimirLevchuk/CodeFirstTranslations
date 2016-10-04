using System;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Reflection
{
    /// <summary>
    /// Factory used to create code member info
    /// </summary>
    public interface ICodeMemberInfoFactory
    {
        [NotNull]
        ICodeMemberInfo Create([NotNull] Type translationsType, [NotNull] string propertyName);
    }
}