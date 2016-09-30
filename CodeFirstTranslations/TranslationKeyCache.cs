using System;
using System.Collections.Generic;

namespace Creuna.CodeFirstTranslations2
{
    public interface ITranslationKeyCache
    {
        void Add(Type translationType, string propertyName,
            string translationKey);

        string TryGet(Type translationType, string propertyName);

        string AddOrGetExisting(Type translationType, string propertyName,
            Func<Type, string, string> getter);
    }

    public class TranslationKeyCache : ITranslationKeyCache
    {
        protected IDictionary<string, string> Storage { get; } = new Dictionary<string, string>(); 
        public static string GetCacheKey(Type translationType, string propertyName)
        {
            return TranslationContext.Current.Environment.CodePropertyKeyBuilder.BuildPropertyKey(translationType, propertyName);
        }

        public virtual void Add(Type translationType, string propertyName, 
            string translationKey)
        {
            Storage[GetCacheKey(translationType, propertyName)] = translationKey;
        }

        public virtual string TryGet(Type translationType, string propertyName)
        {
            string result;
            return Storage.TryGetValue(GetCacheKey(translationType, propertyName), out result) ? result : null;
        }

        public virtual string AddOrGetExisting(Type translationType, string propertyName,
            Func<Type, string, string> getter)
        {
            string result;
            var cacheKey = GetCacheKey(translationType, propertyName);
            if (Storage.TryGetValue(cacheKey, out result))
            {
                return result;
            }

            try
            {
                result = getter(translationType, propertyName);
                Storage[cacheKey] = result;
                return result;
            }
            catch (Exception ex)
            {
                throw new CodeFirstTranslationsException(ErrorMessages.ErrorGettingTranslation, ex);
            }
        }
    }
}