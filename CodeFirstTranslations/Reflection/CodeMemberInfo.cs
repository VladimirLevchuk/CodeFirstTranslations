using System;
using System.Collections.Generic;
using System.Reflection;
using CodeFirstTranslations.CodeAnnotations;
using CodeFirstTranslations.Translations;
using CodeFirstTranslations.Utils;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Reflection
{
    public abstract class CodeMemberInfo : ICodeMemberInfo
    {
        protected CodeMemberInfo([NotNull] Type type, [NotNull] string name)
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
        public string MemberKey => TranslationContext.Current.Environment.CodeMemberKeyBuilder.BuildMemberKey(this);

        public override string ToString()
        {
            return MemberKey;
        }

        [NotNull]
        public virtual List<TAnnotation> GetMemberAnnotations<TAnnotation>()
        {
            return MemberInfo.GetAnnotations<TAnnotation>();
        }

        [CanBeNull]
        protected abstract ITranslation TryGetTranslation();

        [CanBeNull]
        public virtual object GetValue()
        {
            var result = TryGetTranslation()?.Value;
            return result;
        }

        [NotNull]
        public virtual string GetKey()
        {
            var result = TryGetKey();
            if (result == null)
            {
                throw new CodeFirstTranslationsException(ErrorMessages.UnableToGetKeyForMember.Format(this));
            }
            return result;
        }

        [CanBeNull]
        public string TryGetKey()
        {
            var result = TryGetTranslation()?.TryGetKey();
            return result;
        }

        public void TrySetKey(string key)
        {
            var translation = TryGetTranslation();
            if (translation != null)
            {
                translation.Key = key;
            }
        }

        [NotNull]
        public abstract MemberInfo MemberInfo { get; }
    }
}