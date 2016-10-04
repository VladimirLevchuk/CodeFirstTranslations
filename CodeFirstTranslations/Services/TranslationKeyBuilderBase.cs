using System;
using CodeFirstTranslations.Reflection;

namespace CodeFirstTranslations.Services
{
    public abstract class TranslationKeyBuilderBase : ITranslationKeyBuilder
    {
        protected IPathUtil PathUtil { get; }

        protected TranslationKeyBuilderBase(IPathUtil pathUtil)
        {
            PathUtil = pathUtil;
        }

        public virtual string BuildTranslationKey(ICodeMemberInfo codeMember)
        {
            return PathUtil.Combine(GetTranslationTypePath(codeMember.Type), GetTranslationMemberPath(codeMember));
        }

        public abstract string GetTranslationTypePath(Type type);

        public abstract string GetTranslationMemberPath(ICodeMemberInfo codeMember);
    }
}