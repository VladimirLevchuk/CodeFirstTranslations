using System.Collections.Generic;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    public interface IFormat1
    {
        string Format(object arg1);
    }

    public interface IFormat2
    {
        string Format(object arg1, object arg2);
    }

    public interface IFormat3
    {
        string Format(object arg1, object arg2, object arg3);
    }

    public class TranslationFormat1Field : TranslationField, IFormat1
    {
        public virtual string Format(object arg1)
        {
            var result = string.Format(base.ToString(), arg1);
            return result;
        }

        public TranslationFormat1Field([NotNull] string text, [NotNull] string key, [CanBeNull] IEnumerable<string> alternativeKeys = null) : base(text, key, alternativeKeys)
        {
        }
    }

    public class TranslationFormat1Property : TranslationProperty, IFormat1
    {
        public virtual string Format(object arg1)
        {
            var result = string.Format(base.ToString(), arg1);
            return result;
        }

        public TranslationFormat1Property([NotNull] string text, [CanBeNull] IEnumerable<string> alternativeKeys) : base(text, alternativeKeys)
        {
        }

        public TranslationFormat1Property([NotNull] string text) : base(text)
        {
        }
    }

    public class TranslationFormat2Field : TranslationField, IFormat2
    {
        public virtual string Format(object arg1, object arg2)
        {
            var result = string.Format(base.ToString(), arg1, arg2);
            return result;
        }

        public TranslationFormat2Field([NotNull] string text, [NotNull] string key, [CanBeNull] IEnumerable<string> alternativeKeys = null) : base(text, key, alternativeKeys)
        {
        }
    }

    public class TranslationFormat2Property : TranslationProperty, IFormat2
    {
        public virtual string Format(object arg1, object arg2)
        {
            var result = string.Format(base.ToString(), arg1, arg2);
            return result;
        }

        public TranslationFormat2Property([NotNull] string text, [CanBeNull] IEnumerable<string> alternativeKeys) : base(text, alternativeKeys)
        {
        }

        public TranslationFormat2Property([NotNull] string text) : base(text)
        {
        }
    }

    public class TranslationFormat3Field : TranslationField, IFormat3
    {
        public virtual string Format(object arg1, object arg2, object arg3)
        {
            var result = string.Format(base.ToString(), arg1, arg2);
            return result;
        }

        public TranslationFormat3Field([NotNull] string text, [NotNull] string key, [CanBeNull] IEnumerable<string> alternativeKeys = null) : base(text, key, alternativeKeys)
        {
        }
    }

    public class TranslationFormat3Property : TranslationProperty, IFormat3
    {
        public virtual string Format(object arg1, object arg2, object arg3)
        {
            var result = string.Format(base.ToString(), arg1, arg2);
            return result;
        }

        public TranslationFormat3Property([NotNull] string text, [CanBeNull] IEnumerable<string> alternativeKeys) : base(text, alternativeKeys)
        {
        }

        public TranslationFormat3Property([NotNull] string text) : base(text)
        {
        }
    }
}
