using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace Creuna.CodeFirstTranslations2
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
                    string.Format(ErrorMessages.TranslationPropertyNotFound_Format2,
                        Type.FullName, Type.Name)); // TODO: [low] add safe formatting
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