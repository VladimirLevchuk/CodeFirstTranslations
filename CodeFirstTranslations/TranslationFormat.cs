using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    public class TranslationFormat1 : Translation
    {
        public TranslationFormat1([NotNull] string text, [NotNull] string key, params string[] alternativeKeys) : base(text, key, alternativeKeys)
        {
        }

        public TranslationFormat1([NotNull] string text) : base(text)
        {
        }

        public virtual string Format(object arg1)
        {
            var result = string.Format(base.ToString(), arg1);
            return result;
        }
    }

    public class TranslationFormat2 : Translation
    {
        public TranslationFormat2([NotNull] string text, [NotNull] string key, params string[] alternativeKeys) : base(text, key, alternativeKeys)
        {
        }

        public TranslationFormat2([NotNull] string text) : base(text)
        {
        }

        public virtual string Format(object arg1, object arg2)
        {
            var result = string.Format(base.ToString(), arg1, arg2);
            return result;
        }
    }

    public class TranslationFormat3 : Translation
    {
        public TranslationFormat3([NotNull] string text, [NotNull] string key, params string[] alternativeKeys) : base(text, key, alternativeKeys)
        {
        }

        public TranslationFormat3([NotNull] string text) : base(text)
        {
        }

        public virtual string Format(object arg1, object arg2, object arg3)
        {
            var result = string.Format(base.ToString(), arg1, arg2);
            return result;
        }
    }
}
