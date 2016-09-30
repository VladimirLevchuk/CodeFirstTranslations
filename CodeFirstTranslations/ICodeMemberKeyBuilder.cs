using JetBrains.Annotations;

namespace Creuna.CodeFirstTranslations2
{
    public interface ICodeMemberKeyBuilder
    {
        string BuildMemberKey([NotNull] ICodeMemberInfo codeMemberInfo);
    }
}