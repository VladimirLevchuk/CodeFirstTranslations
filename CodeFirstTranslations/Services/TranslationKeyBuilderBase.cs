using System;
using CodeFirstTranslations.Reflection;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
{
    public abstract class TranslationKeyBuilderBase : ITranslationKeyGenerator
    {
        [NotNull]
        protected IPathUtil PathUtil { get; }

        protected TranslationKeyBuilderBase([NotNull] IPathUtil pathUtil)
        {
            if (pathUtil == null) throw new ArgumentNullException(nameof(pathUtil));
            PathUtil = pathUtil;
        }

        public virtual string GenerateTranslationKey(ICodeMemberInfo codeMember)
        {
            return PathUtil.Combine(GenerateTranslationTypePath(codeMember.Type), GenerateTranslationMemberPath(codeMember));
        }

        public abstract string GenerateTranslationTypePath(Type type);

        public abstract string GenerateTranslationMemberPath(ICodeMemberInfo codeMember);
    }
}