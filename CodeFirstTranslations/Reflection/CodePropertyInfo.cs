using System;
using System.Collections.Generic;
using System.Reflection;
using CodeFirstTranslations.CodeAnnotations;
using CodeFirstTranslations.Translations;
using JetBrains.Annotations;

namespace CodeFirstTranslations
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
                    ErrorMessages.TranslationPropertyNotFound.Format(Type.FullName, Type.Name));
            }

            return propertyInfo;
        }

        public CodePropertyInfo(Type type, string name) : base(type, name)
        {
        }

        public override List<TAnnotation> GetMemberAnnotations<TAnnotation>()
        {
            return GetPropertyInfo().GetAnnotations<TAnnotation>();
        }
    }
}