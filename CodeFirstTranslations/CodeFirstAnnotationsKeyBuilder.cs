using System;
using System.Collections.Generic;
using System.Linq;
using Creuna.CodeFirstTranslations2.CodeAnnotations;

namespace Creuna.CodeFirstTranslations2
{
    public class CodeFirstAnnotationsKeyBuilder : ITranslationKeyBuilder
    {
        protected IPathUtil PathUtil { get; }
        protected IPathOverrides PathOverrides { get; }
        protected ICodeMemberKeyBuilder CodeMemberKeyBuilder { get; }
        IDictionary<string, string> ClassPathOverrides { get; }
        IDictionary<string, string> MemberPathOverrides { get; }

        public CodeFirstAnnotationsKeyBuilder(
            IPathOverrides pathOverrides,
            IPathUtil pathUtil, 
            ICodeMemberKeyBuilder codeMemberKeyBuilder)
        {
            PathUtil = pathUtil;
            PathOverrides = pathOverrides;
            CodeMemberKeyBuilder = codeMemberKeyBuilder;
            ClassPathOverrides = pathOverrides?.ClassPathOverrides ?? new Dictionary<string, string>();
            MemberPathOverrides = pathOverrides?.MemberPathOverrides ?? new Dictionary<string, string>();
        }

        public virtual string BuildTranslationKey(ICodeMemberInfo codeMember)
        {
            if (codeMember == null) throw new ArgumentNullException(nameof(codeMember));

            var classPath = ClassPathOverrides.TryGetValue(codeMember.Type.FullName)
                ?? codeMember.GetTypeAnnotations<ITranslationsPathProvider>().FirstOrDefault()?.Path
                ?? codeMember.DefaultTypePath;

            var propertyPath =
                MemberPathOverrides.TryGetValue(CodeMemberKeyBuilder.BuildMemberKey(codeMember))
                ?? codeMember.GetMemberAnnotations<ITranslationsPathProvider>().FirstOrDefault()?.Path
                ?? codeMember.DefaultPropertyPath;

            var result = PathUtil.Combine(classPath, propertyPath);
            return result;
        }
    }
}