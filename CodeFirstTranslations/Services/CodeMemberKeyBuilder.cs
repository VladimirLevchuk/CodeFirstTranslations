using System;

namespace CodeFirstTranslations.Services
{
    public class CodeMemberKeyBuilder : ICodeMemberKeyBuilder
    {
        public virtual string BuildMemberKey(ICodeMemberInfo codeMemberInfo)
        {
            if (codeMemberInfo == null) throw new ArgumentNullException(nameof(codeMemberInfo));
            return $"{codeMemberInfo.Type.FullName}->{codeMemberInfo.Name}";
        }
    }
}