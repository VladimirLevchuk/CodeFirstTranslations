using System;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    public class TranslationTypeInfo
    {
        public TranslationTypeInfo([NotNull] Type type, [NotNull] string path)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (path == null) throw new ArgumentNullException(nameof(path));
            Type = type;
            Path = path;
        }

        [NotNull]
        public Type Type { get; }
        [NotNull]
        public string Path { get; }
    }

    public class TranslationTypeInfo<TTranslation> : TranslationTypeInfo
    {
        public TranslationTypeInfo([NotNull] string path) : base(typeof(TTranslation), path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
        }
    }
}