using System;

namespace CodeFirstTranslations.Services
{
    public class CodeMemberFactory : ICodeMemberInfoFactory
    {
        public virtual ICodeMemberInfo Create(Type type, string memberName)
        {
            return type.IsEnum 
                ? (ICodeMemberInfo) new EnumMemberInfo(type, memberName) 
                : new CodePropertyInfo(type, memberName);
        }
    }
}