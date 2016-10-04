using CodeFirstTranslations.Reflection;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
{
    /// <summary>
    /// Build code member key
    /// used to identify code member (i.e. property or enum member)
    /// </summary>
    public interface ICodeMemberKeyBuilder
    {
        [NotNull]
        string BuildMemberKey([NotNull] ICodeMemberInfo codeMemberInfo);
    }
}