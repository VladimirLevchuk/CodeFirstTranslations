using System.Collections.Generic;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    public class TranslationField<TTranslation> : Translation
    {
        public TranslationField([NotNull] string fieldName,
            [NotNull] string text, [CanBeNull] IEnumerable<string> alternativeKeys = null) : base(text, 
                GenerateFieldKey(fieldName), alternativeKeys)
        {
        }

        public static string GenerateFieldKey(string fieldName)
        {
            var env = TranslationContext.Current.Environment;
            var info = env.CodeMemberInfoFactory.Create(typeof(TTranslation), fieldName);
            var key = env.TranslationKeyBuilder.GenerateTranslationKey(info);
            return key;
        }
    }

    public class TranslationField : Translation
    {
        public TranslationField([NotNull] string text, [CanBeNull] string key = null, 
            [CanBeNull] IEnumerable<string> alternativeKeys = null) : base(text, key, alternativeKeys)
        {
        }
    }
}