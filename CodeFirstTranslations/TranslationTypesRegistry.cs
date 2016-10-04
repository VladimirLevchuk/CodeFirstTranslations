using System;
using System.Collections.Generic;
using System.Linq;
using CodeFirstTranslations.Services;
using CodeFirstTranslations.Translations;
using CodeFirstTranslations.Utils;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    public class TranslationTypesRegistry : ITranslationTypesRegistry
    {
        public TranslationTypesRegistry(string defaultCulture, ITranslationKeyBuilder translationKeyBuilder)
        {
            DefaultCulture = defaultCulture;
            TranslationKeyBuilder = translationKeyBuilder;
        }

        protected ITranslationKeyBuilder TranslationKeyBuilder { get; }

        protected Dictionary<Type, string> Types { get; }  = new Dictionary<Type, string>();

        public string DefaultCulture { get; }

        public ITranslationTypesRegistry Add<TTranslations>(string classPath = null)
        {
            return Add(typeof(TTranslations), classPath);
        }

        public ITranslationTypesRegistry Add(Type translationsType, [CanBeNull] string classPath = null)
        {
            if (translationsType == null) throw new ArgumentNullException(nameof(translationsType));
            Types.Add(translationsType, GetOrGenerateClassPath(translationsType, classPath));
            return this;
        }

        public ITranslationTypesRegistry AddEnum<TEnum, TTranslations>([CanBeNull] string classPath = null)
        {
            return AddEnum(typeof (TEnum), typeof (TTranslations), classPath);
        }

        public ITranslationTypesRegistry AddEnum([NotNull] Type enumType, [NotNull] Type translationsType, [CanBeNull] string classPath = null)
        {
            if (enumType == null) throw new ArgumentNullException(nameof(enumType));
            if (translationsType == null) throw new ArgumentNullException(nameof(translationsType));
            var path = GetOrGenerateClassPath(translationsType, classPath);
            Types.Add(translationsType, path);
            Types.Add(enumType, path);
            return this;
        }

        protected virtual string GetOrGenerateClassPath([NotNull] Type translationsType, [CanBeNull] string classPath)
        {
            if (translationsType == null) throw new ArgumentNullException(nameof(translationsType));
            return classPath ?? TranslationKeyBuilder.GetTranslationTypePath(translationsType);
        }

        public virtual ITranslationTypesRegistry AddRange([NotNull] IEnumerable<TranslationTypeInfo> typeInfos)
        {
            if (typeInfos == null) throw new ArgumentNullException(nameof(typeInfos));
            foreach (var typeInfo in typeInfos)
            {
                Add(typeInfo.Type, typeInfo.Path);
            }
            return this;
        }

        public virtual ITranslationTypesRegistry AddRange([NotNull] IEnumerable<Type> types)
        {
            if (types == null) throw new ArgumentNullException(nameof(types));
            foreach (var type in types)
            {
                Add(type);
            }
            
            return this;
        }

        public virtual IList<TranslationTypeInfo> ToList()
        {
            return Types.Select(x => new TranslationTypeInfo(x.Key, x.Value)).ToList();
        }

        public virtual string TryGetTypePath([NotNull] Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var result = Types.TryGetValue(type);
            return result;
        }

        public virtual string GetTypePath([NotNull] Type translationsType)
        {
            if (translationsType == null) throw new ArgumentNullException(nameof(translationsType));
            var result = TryGetTypePath(translationsType);
            if (result == null)
            {
                throw new CodeFirstTranslationsException(ErrorMessages.TranslationsTypeNotFound.Format(translationsType));
            }
            return result;
        }

        public virtual bool Contains([NotNull] Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return Types.ContainsKey(type);
        }
    }
}