using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Creuna.CodeFirstTranslations2
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

        public virtual string MemberId => $"{Type.FullName}->{Name}";

        public override string ToString()
        {
            return MemberId;
        }

        public virtual List<TAnnotation> GetTypeAnnotations<TAnnotation>()
        {
            return Type.GetAnnotations<TAnnotation>();
        }
        public abstract List<TAnnotation> GetMemberAnnotations<TAnnotation>();
    }
}