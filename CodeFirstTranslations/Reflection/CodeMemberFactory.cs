using System;
using System.Reflection;
using CodeFirstTranslations.Translations;
using CodeFirstTranslations.Utils;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Reflection
{
    public class CodeMemberFactory : ICodeMemberInfoFactory
    {
        public virtual ICodeMemberInfo Create(Type translationsType, string memberName)
        {
            if (translationsType == null) throw new ArgumentNullException(nameof(translationsType));
            if (memberName == null) throw new ArgumentNullException(nameof(memberName));
            return translationsType.IsEnum 
                ? new EnumMemberInfo(translationsType, memberName) 
                : CreateClassMemberInfo(translationsType, memberName);
        }

        [NotNull]
        private ICodeMemberInfo CreateClassMemberInfo([NotNull] Type type, [NotNull] string memberName)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (memberName == null) throw new ArgumentNullException(nameof(memberName));

            var field = type.GetField(memberName, BindingFlags.Static | BindingFlags.Public);
            if (field != null)
            {
                return new CodeFieldInfo(type, memberName);
            }

            var property = type.GetProperty(memberName, BindingFlags.Public | BindingFlags.Static);

            if (property != null && property.CanRead)
            {
                return new CodePropertyInfo(type, memberName);
            }

            throw new CodeFirstTranslationsException(ErrorMessages.TranslationMemberNotFound.Format(type, memberName));
        }
    }
}