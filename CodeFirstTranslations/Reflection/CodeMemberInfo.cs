using System;
using System.Collections.Generic;
using CodeFirstTranslations.CodeAnnotations;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Reflection
{
    public abstract class CodeMemberInfo : ICodeMemberInfo
    {
        public CodeMemberInfo([NotNull] Type type, [NotNull] string name)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (name == null) throw new ArgumentNullException(nameof(name));
            Type = type;
            Name = name;
        }

        [NotNull]
        public virtual Type Type { get; }
        [NotNull]
        public virtual string Name { get; }

        [NotNull]
        public virtual string DefaultPropertyPath => Name;

        [NotNull]
        public virtual string DefaultTypePath => Type.Name;

        public string MemberKey => TranslationContext.Current.Environment.CodeMemberKeyBuilder.BuildMemberKey(this);

        public override string ToString()
        {
            return MemberKey;
        }

        public virtual List<TAnnotation> GetTypeAnnotations<TAnnotation>()
        {
            return Type.GetAnnotations<TAnnotation>();
        }
        public abstract List<TAnnotation> GetMemberAnnotations<TAnnotation>();
    }
}