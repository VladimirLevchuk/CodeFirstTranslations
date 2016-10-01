using System;

namespace CodeFirstTranslations
{
    /// <summary>
    /// Factory used to create code member info
    /// </summary>
    public interface ICodeMemberInfoFactory
    {
        ICodeMemberInfo Create(Type type, string propertyName);
    }
}