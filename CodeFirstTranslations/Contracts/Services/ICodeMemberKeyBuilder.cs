using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    /// <summary>
    /// Build code member key
    /// used to identify code member (i.e. property or enum member)
    /// </summary>
    public interface ICodeMemberKeyBuilder
    {
        string BuildMemberKey([NotNull] ICodeMemberInfo codeMemberInfo);
    }
}