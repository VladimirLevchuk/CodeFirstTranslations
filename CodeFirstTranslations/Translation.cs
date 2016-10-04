using System;
using System.Collections.Generic;
using System.Linq;
using CodeFirstTranslations.Utils;
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

        /// <summary>
        /// Value is a translation text, translated to the current culture (see TranslationContext.Current.CurrentCulrure
        /// </summary>
        [NotNull]
        public virtual string Value => Translate(TranslationContext.Current);
        /// <summary>
        /// Translation key (primary)
        /// </summary>
        [NotNull]
        public virtual string Key { get; }
        /// <summary>
        /// Alternative translation keys
        /// </summary>
        [NotNull]
        public virtual List<string> AlternativeKeys { get; }
        /// <summary>
        /// Default code-first value is used as a fallback for all cultures translation service cannot find translation for
        /// </summary>
        [NotNull]
        public virtual string DefaultValue { get; }

        [NotNull]
        public override string ToString()
        {
            return Value;
        }

        /// <summary>
        /// Returns code first value for a given culture. 
        /// When currentCulture is null, or text for the culture is not defined in code Default value is returned
        /// </summary>
        /// <param name="currentCulture"></param>
        /// <returns></returns>
        [NotNull]
        public virtual string GetCodeFirstValueFor([CanBeNull] string currentCulture)
        {
            if (currentCulture == null)
                return DefaultValue;

            return _data.TryGetValue(currentCulture) ?? DefaultValue;
        }
        /// <summary>
        /// Defines a code-first translation with the given text for the culture specified
        /// </summary>
        /// <param name="culture"></param>
        /// <param name="text"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Translates the current translation text to the current culture taken from translation context
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        protected virtual string Translate([NotNull] IReadOnlyTranslationContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var result = context.Environment.TranslationService.Translate(Key, GetCodeFirstValueFor(context.CurrentCulture));

            return result;
        }
    }
}