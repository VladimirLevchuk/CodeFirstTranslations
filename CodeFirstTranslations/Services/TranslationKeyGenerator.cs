using System;
using CodeFirstTranslations.Reflection;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
{
    public class TranslationKeyGenerator : TranslationKeyBuilderBase
    {
        public TranslationKeyGenerator([NotNull] IPathUtil pathUtil) : base(pathUtil)
        {
        }

        public override string GenerateTranslationTypePath([NotNull] Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            return PathUtil.MakeKey(PathUtil.Root + type.Name);
        }

        public override string GenerateTranslationMemberPath([NotNull] ICodeMemberInfo codeMember)
        {
            if (codeMember == null) throw new ArgumentNullException(nameof(codeMember));

            return PathUtil.MakeKey(codeMember.Name);
        }
    }
}