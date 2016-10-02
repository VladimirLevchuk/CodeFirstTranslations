using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    public abstract class Translation
    {
        private Dictionary<string, string> _data = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public Translation([NotNull] string text, [NotNull] string key, [CanBeNull] IEnumerable<string> alternativeKeys = null)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            if (key == null) throw new ArgumentNullException(nameof(key));

            DefaultValue = text;
            Key = TranslationContext.Current.Environment.PathUtil.MakeKey(key);
            AlternativeKeys = alternativeKeys.OrEmpty().Select(TranslationContext.Current.Environment.PathUtil.MakeKey).ToList();
        }

        [NotNull]
        public virtual string Value => Translate(TranslationContext.Current);
        [NotNull]
        public virtual string Key { get; }
        [NotNull]
        public virtual List<string> AlternativeKeys { get; }
        [NotNull]
        public virtual string DefaultValue { get; }

        public override string ToString()
        {
            return Value;
        }

        [NotNull]
        public virtual string GetCodeFirstValueFor([CanBeNull] string currentCulture)
        {
            if (currentCulture == null)
                return DefaultValue;

            return _data.TryGetValue(currentCulture) ?? DefaultValue;
        }
        [NotNull]
        public Translation AddTranslation([NotNull] string culture, [NotNull] string text)
        {
            if (culture == null) throw new ArgumentNullException(nameof(culture));
            if (text == null) throw new ArgumentNullException(nameof(text));
            _data[culture] = text;
            return this;
        }

        [NotNull]
        public virtual IDictionary<string, string> ToDictionary()
        {
            return _data.ToDictionary(x => x.Key, x => x.Value, StringComparer.InvariantCultureIgnoreCase);
        }

        protected virtual string Translate(IReadOnlyTranslationContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var result = context.Environment.TranslationService.Translate(Key, GetCodeFirstValueFor(context.CurrentCulture));

            return result;
        }
    }
}