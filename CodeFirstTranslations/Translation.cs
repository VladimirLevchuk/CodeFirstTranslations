using System;
using System.Collections.Generic;
using System.Linq;
using CodeFirstTranslations.Utils;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    /// <summary>
    /// Code-first translation
    /// </summary>
    public interface ITranslation
    {
        /// <summary>
        /// Returns code-first value
        /// </summary>
        [CanBeNull]
        string Value { get; }
        /// <summary>
        /// Returns code-first key. 
        /// Throws an exception if key is null 
        /// (it might happen when called before keys autogeneration)
        /// </summary>
        [NotNull]
        string Key { get; set; }
        /// <summary>
        /// Returns key (if any) or null
        /// </summary>
        /// <returns></returns>
        [CanBeNull]
        string TryGetKey();
    }

    /// <summary>
    /// Base code-first translation implementation
    /// </summary>
    public abstract class Translation : ITranslation
    {
        [NotNull]
        private Dictionary<string, string> _data = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        [CanBeNull]
        private string _key;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text">Code-first translation value</param>
        /// <param name="key">Code-first translation key. Can be null for auto-generated keys</param>
        /// <param name="alternativeKeys">Alternative keys if any</param>
        public Translation([NotNull] string text, [CanBeNull] string key, 
            [CanBeNull] IEnumerable<string> alternativeKeys = null)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            DefaultValue = text;
            _key = key != null ? TranslationContext.Current.Environment.PathUtil.MakeKey(key) : null;
            AlternativeKeys = alternativeKeys.OrEmpty().Select(TranslationContext.Current.Environment.PathUtil.MakeKey).ToList();
        }

        /// <summary>
        /// Value is a translation text, translated to the current culture 
        /// (see TranslationContext.Current.CurrentCulture)
        /// </summary>
        [CanBeNull]
        public virtual string Value => Translate(TranslationContext.Current);

        /// <summary>
        /// Translation key (primary)
        /// </summary>
        [NotNull]  
        public virtual string Key
        {
            get
            {
                var result = TryGetKey();
                if (result == null)
                {
                    throw new CodeFirstTranslationsException("Key accessed before initialization completed.If you really need it please use TryGetKey");
                }
                return result;
            }
            set
            {
                if (_key != null)
                {
                    throw new CodeFirstTranslationsException("It's allowed to set key either from ctor or once during auto-generation");
                }
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                _key = TranslationContext.Current.Environment.PathUtil.MakeKey(value);
            }
        }

        public string TryGetKey()
        {
            return _key;
        }

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
            return Value ?? string.Empty;
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

            var result = context.Environment.TranslationService.Translate(Key, 
                GetCodeFirstValueFor(context.CurrentCulture));

            return result;
        }
    }
}