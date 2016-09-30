using System.Diagnostics;
using System.Linq;

namespace Creuna.CodeFirstTranslations2
{
    public interface ITranslationKeySpy
    {
        string GetTranslationKeyFromCallStack();
    }

    public class TranslationKeySpy : ITranslationKeySpy
    {
        protected ICodeMemberInfoFactory CodeMemberInfoFactory { get; }

        public TranslationKeySpy(ICodeMemberInfoFactory codeMemberInfoFactory)
        {
            CodeMemberInfoFactory = codeMemberInfoFactory;
        }

        protected ITranslationsEnvironment Environment => TranslationContext.Current.Environment;

        public virtual string GetTranslationKeyFromCallStack()
        {
            var translationClasses = Environment.TranslationClasses;
            var stackFrames = new StackTrace();
            var frames = stackFrames.GetFrames();
            foreach (var stackFrame in frames ?? Enumerable.Empty<StackFrame>())
            {
                var method = stackFrame.GetMethod();
                if (method?.Name == null)
                    continue;

                const string prefix = "get_";

                if (method.Name.StartsWith(prefix) && translationClasses.Contains(method.DeclaringType))
                {
                    var propertName = method.Name.Substring(prefix.Length);
                    var codeProperty = CodeMemberInfoFactory.Create(method.DeclaringType, propertName);
                    var key = Environment.TranslationKeyBuilder.BuildTranslationKey(codeProperty);
                    return key;
                }
            }
            throw new CodeFirstTranslationsException(ErrorMessages.UnableToFindKeyFromCurrentStack);
        }
    }
}