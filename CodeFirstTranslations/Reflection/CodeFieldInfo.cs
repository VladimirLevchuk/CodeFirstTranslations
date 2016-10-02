using System;
using System.Collections.Generic;
using System.Reflection;
using CodeFirstTranslations.CodeAnnotations;
using CodeFirstTranslations.Translations;
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
                    ErrorMessages.TranslationPropertyNotFound.Format(Type.FullName, Type.Name));
            }

            return fieldInfo;
        }

        public override List<TAnnotation> GetMemberAnnotations<TAnnotation>()
        {
            return GetFieldInfo().GetAnnotations<TAnnotation>();
        }
    }
}