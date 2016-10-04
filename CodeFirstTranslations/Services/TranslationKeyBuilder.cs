using System;
using CodeFirstTranslations.Reflection;

namespace CodeFirstTranslations.Services
{
    public class TranslationKeyBuilder : TranslationKeyBuilderBase
    {
        public TranslationKeyBuilder(IPathUtil pathUtil) : base(pathUtil)
        {
        }

        public override string GetTranslationTypePath(Type type)
        {
            return type.Name;
        }

        public override string GetTranslationMemberPath(ICodeMemberInfo codeMember)
        {
            return codeMember.Name;
        }
    }
}