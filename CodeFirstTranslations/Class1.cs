using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Creuna.CodeFirstTranslations2
{
    namespace CodeAnnotations
    {
        public interface ITranslationsPathProvider
        {
            string Path { get; }
        }

        public class TranslationClassAttribute 
            : Attribute, ITranslationsPathProvider
        {
            public string Path { get; set; }
        }

        public class TranslationPathAttribute : Attribute
        {
            
        }

        public class TranslationKeyAttribute : Attribute
        {
            
        }
    }

    public interface ITranslationKeyBuilder
    {
        [NotNull]
        string BuildTranslationKey([NotNull] ICodeMemberInfo codeMember);
    }




    public class T
    {
        private Dictionary<string, string> _data = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
        public T(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            DefaultValue = text;
            Key = TranslationContext.Current.Environment.TranslationKeySpy.GetTranslationKeyFromCallStack();
        }

        public static implicit operator string(T t)
        {
            return t?.ToString();
        }

        public virtual string ToString(IReadOnlyTranslationContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            var result = context.Environment.TranslationService.Translate(Key, GetCodeFirstValueFor(context.CurrentCulture));

            return result;
        }

        [NotNull]
        public virtual string GetCodeFirstValueFor([CanBeNull] string currentCulture)
        {
            if (currentCulture == null)
                return DefaultValue;

            string result;
            return _data.TryGetValue(currentCulture, out result) ? result : DefaultValue;
        }

        public override string ToString()
        {
            return ToString(TranslationContext.Current);
        }

        public virtual IDictionary<string, string> ToDictionary()
        {
            return _data.ToDictionary(x => x.Key, x => x.Value, StringComparer.InvariantCultureIgnoreCase);
        }

        public T AddTranslation([CanBeNull] string culture, [NotNull] string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));
            _data[culture ?? DefaultKey] = text;
            return this;
        }

        public const string DefaultKey = "_";

        [NotNull]
        public string Key { get; }
        [NotNull]
        public string DefaultValue { get; }
    }

    public static class TranslationExtensions
    {
        public static T no(this T translation, string text)
        {
            return translation.AddTranslation("no", text);
        }
        public static T en(this T translation, string text)
        {
            return translation.AddTranslation("en", text);
        }
    }

    public class en : T
    {
        public en(string text) : base(text)
        {
            this.AddTranslation("en", text);
        }
    }

    public class no : T
    {
        public no(string text) : base(text)
        {
            this.AddTranslation("no", text);
        }
    }
}
