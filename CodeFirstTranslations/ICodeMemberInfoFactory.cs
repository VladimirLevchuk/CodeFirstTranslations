using System;

namespace Creuna.CodeFirstTranslations2
{
    public interface ICodeMemberInfoFactory
    {
        ICodeMemberInfo Create(Type type, string propertyName);
    }
}