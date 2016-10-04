using System;
using System.Reflection;
using CodeFirstTranslations.Translations;
using CodeFirstTranslations.Utils;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Reflection
{
    public class CodeFieldInfo : CodeMemberInfo
    {
        public CodeFieldInfo([NotNull] Type type, [NotNull] string name) : base(type, name)
        {
        }

        [NotNull]
        public virtual FieldInfo GetFieldInfo()
        {
            var fieldInfo =
                Type.GetField(Name, BindingFlags.Public | BindingFlags.Static);
            if (fieldInfo == null)
            {
                throw new CodeFirstTranslationsException(
                    ErrorMessages.TranslationMemberNotFound.Format(Type.FullName, Type.Name));
            }

            return fieldInfo;
        }

        public override MemberInfo MemberInfo => GetFieldInfo();
    }
}