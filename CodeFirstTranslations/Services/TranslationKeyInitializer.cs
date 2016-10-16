using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CodeFirstTranslations.Reflection;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
{
    public class TranslationKeyInitializer : ITranslationKeyInitializer
    {
        public TranslationKeyInitializer([NotNull] ICodeMemberInfoFactory codeMemberInfoFactory,
            [NotNull] ITranslationKeyGenerator translationKeyBuilder)
        {
            if (codeMemberInfoFactory == null) throw new ArgumentNullException(nameof(codeMemberInfoFactory));
            if (translationKeyBuilder == null) throw new ArgumentNullException(nameof(translationKeyBuilder));
            CodeMemberInfoFactory = codeMemberInfoFactory;
            TranslationKeyBuilder = translationKeyBuilder;
        }

        [NotNull]
        protected ICodeMemberInfoFactory CodeMemberInfoFactory { get; }

        [NotNull]
        protected ITranslationKeyGenerator TranslationKeyBuilder { get; }

        public virtual void AutoGenerateMissedKeys(ITranslationTypesRegistry translationTypesRegistry)
        {
            if (translationTypesRegistry == null) throw new ArgumentNullException(nameof(translationTypesRegistry));

            foreach (var translationTypeInfo in translationTypesRegistry.ToList())
            {
                if (translationTypeInfo.Type.IsEnum)
                    continue;

                foreach (var codeMemberInfo in GetTypeMembers(translationTypeInfo.Type))
                {
                    var key = codeMemberInfo.TryGetKey();
                    if (key != null)
                        continue;
                    key = TranslationKeyBuilder.GenerateTranslationKey(codeMemberInfo);
                    codeMemberInfo.TrySetKey(key);
                }
            }
        }

        protected virtual IEnumerable<ICodeMemberInfo> GetTypeMembers([NotNull] Type translationsType)
        {
            if (translationsType == null) throw new ArgumentNullException(nameof(translationsType));

            var translationFields = translationsType.GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x != null && typeof(ITranslation).IsAssignableFrom(x.FieldType)).Cast<MemberInfo>();

            var translationProperties = translationsType.GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(x => x != null && typeof(ITranslation).IsAssignableFrom(x.PropertyType)).Cast<MemberInfo>();

            var result = translationFields.Union(translationProperties)
                .Select(x => CodeMemberInfoFactory.Create(translationsType, x.Name));
            return result;
        }
    }
}