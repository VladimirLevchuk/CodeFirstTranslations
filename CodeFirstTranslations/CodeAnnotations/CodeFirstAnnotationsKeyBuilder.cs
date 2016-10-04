using System;
using System.Collections.Generic;
using System.Linq;
using CodeFirstTranslations.Services;

namespace CodeFirstTranslations.CodeAnnotations
{
    public class CodeFirstAnnotationsKeyBuilder : TranslationKeyBuilderBase
    {
        protected IPathOverrides PathOverrides { get; }
        protected ICodeMemberKeyBuilder CodeMemberKeyBuilder { get; }
        IDictionary<string, string> ClassPathOverrides { get; }
        IDictionary<string, string> MemberPathOverrides { get; }

        public CodeFirstAnnotationsKeyBuilder(
            IPathOverrides pathOverrides,
            IPathUtil pathUtil, 
            ICodeMemberKeyBuilder codeMemberKeyBuilder) : base(pathUtil)
        {
            PathOverrides = pathOverrides;
            CodeMemberKeyBuilder = codeMemberKeyBuilder;
            ClassPathOverrides = pathOverrides?.ClassPathOverrides ?? new Dictionary<string, string>();
            MemberPathOverrides = pathOverrides?.MemberPathOverrides ?? new Dictionary<string, string>();
        }

        public override string GetTranslationTypePath(Type type)
        {
            var classPath = ClassPathOverrides.TryGetValue(type.FullName)
                ?? type.GetAnnotations<ITranslationsPathProvider>().FirstOrDefault()?.Path
                ?? codeMember.DefaultTypePath;
        }

        public override string GetTranslationMemberPath(ICodeMemberInfo codeMember)
        {
            var memberPath = MemberPathOverrides.TryGetValue(CodeMemberKeyBuilder.BuildMemberKey(codeMember))
                    ?? codeMember.GetMemberAnnotations<ITranslationsPathProvider>().FirstOrDefault()?.Path
                    ?? codeMember.DefaultPropertyPath;

            return memberPath;
        }
    }
}