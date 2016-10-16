using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    public class StringTranslationProperty : TranslationProperty
    {
        public StringTranslationProperty([NotNull] string text, [CanBeNull] IEnumerable<string> alternativeKeys) 
            : base(text, alternativeKeys)
        {
        }

        public StringTranslationProperty([NotNull] string text) : base(text)
        {
        }

        public static implicit operator string(StringTranslationProperty translation)
        {
            return translation?.ToString();
        }

        public static string GetKey([NotNull] Type translationType, [NotNull] string memberName)
        {
            if (translationType == null) throw new ArgumentNullException(nameof(translationType));
            if (memberName == null) throw new ArgumentNullException(nameof(memberName));

            var codeMemberInfo = TranslationContext.Current.Environment.CodeMemberInfoFactory.Create(
                translationType, memberName);

            var key = TranslationContext.Current.Environment.TranslationKeyBuilder.GenerateTranslationKey(codeMemberInfo);
            return key;
        }

        public static string GetKey<TTranslation>([NotNull] string memberName)
        {
            if (memberName == null) throw new ArgumentNullException(nameof(memberName));
            return GetKey(typeof (TTranslation), memberName);
        }
    }
}