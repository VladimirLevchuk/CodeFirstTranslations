using System;
using System.Reflection;
using CodeFirstTranslations.Translations;
using CodeFirstTranslations.Utils;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Reflection
{
    public class CodePropertyInfo : CodeMemberInfo
    {
        [NotNull]
        public virtual PropertyInfo GetPropertyInfo()
        {
            var propertyInfo = 
                Type.GetProperty(Name, BindingFlags.Public | BindingFlags.Static);
            if (propertyInfo == null)
            {
                throw new CodeFirstTranslationsException(
                    ErrorMessages.TranslationMemberNotFound.Format(Type.FullName, Type.Name));
            }

            return propertyInfo;
        }

        public CodePropertyInfo([NotNull] Type type, [NotNull] string name) : base(type, name)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (name == null) throw new ArgumentNullException(nameof(name));
        }

        public override MemberInfo MemberInfo => GetPropertyInfo();
    }
}