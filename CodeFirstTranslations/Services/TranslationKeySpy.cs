using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using CodeFirstTranslations.Translations;

namespace CodeFirstTranslations.Services
{
    public class TranslationKeySpy : ITranslationKeySpy
    {
        protected ICodeMemberInfoFactory CodeMemberInfoFactory { get; }

        public TranslationKeySpy(ICodeMemberInfoFactory codeMemberInfoFactory)
        {
            CodeMemberInfoFactory = codeMemberInfoFactory;
        }

        protected ITranslationsEnvironment Environment => TranslationContext.Current.Environment;

        private string KeyFromMethod(MethodBase method, ITranslationClasses translationClasses)
        {
            const string prefix = "get_";

            if (method.Name.StartsWith(prefix) && translationClasses.Contains(method.DeclaringType))
            {
                var propertName = method.Name.Substring(prefix.Length);
                var codeProperty = CodeMemberInfoFactory.Create(method.DeclaringType, propertName);
                var key = Environment.TranslationKeyBuilder.BuildTranslationKey(codeProperty);
                return key;
            }

            return null;
        }

        public virtual string GenerateTranslationKeyFromCallStack()
        {
            var translationClasses = Environment.TranslationClasses;
            var key = KeyFromMethod(new StackFrame(2).GetMethod(), translationClasses)
                ?? KeyFromMethod(new StackFrame(3).GetMethod(), translationClasses)
                ?? KeyFromMethod(new StackFrame(4).GetMethod(), translationClasses)
                ?? KeyFromMethod(new StackFrame(5).GetMethod(), translationClasses);

            if (key == null)
            {
                var stackTrace = new StackTrace();
                var stackFrames = stackTrace.GetFrames().OrEmpty().Skip(5);

                foreach (var stackFrame in stackFrames)
                {
                    key = KeyFromMethod(stackFrame.GetMethod(), translationClasses);
                    if (key != null)
                    {
                        break;
                    }
                }

                if (key == null)
                {
                    throw new CodeFirstTranslationsException(ErrorMessages.UnableToFindKeyFromCurrentStack.ToString());
                }
            }

            return key;
        }
    }
}