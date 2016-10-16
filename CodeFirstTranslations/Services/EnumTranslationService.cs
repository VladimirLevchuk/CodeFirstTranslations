using System;
using CodeFirstTranslations.Reflection;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
{
    public class EnumTranslationService : IEnumTranslationService
    {
        public EnumTranslationService([NotNull] ICodeMemberInfoFactory codeMemberInfoFactory,
            [NotNull] ITranslationTypesRegistry translationTypesRegistry)
        {
            if (codeMemberInfoFactory == null) throw new ArgumentNullException(nameof(codeMemberInfoFactory));
            if (translationTypesRegistry == null) throw new ArgumentNullException(nameof(translationTypesRegistry));

            CodeMemberInfoFactory = codeMemberInfoFactory;
            TranslationTypesRegistry = translationTypesRegistry;
        }

        [NotNull]
        protected ICodeMemberInfoFactory CodeMemberInfoFactory { get; }
        [NotNull]
        protected ITranslationTypesRegistry TranslationTypesRegistry { get; }

        public virtual string Translate(Enum enumValue)
        {
            if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));

            var translationsType = TranslationTypesRegistry.GetEnumTranslationsType(enumValue.GetType());
            return Translate(translationsType, enumValue);
        }

        [CanBeNull]
        public virtual string Translate([NotNull] Type translationsType, [NotNull] Enum enumValue)
        {
            if (translationsType == null) throw new ArgumentNullException(nameof(translationsType));
            if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));

            var memberInfo = GetTranslationsMemberInfo(translationsType, enumValue);
            var result = memberInfo.GetValue()?.ToString();
            return result;
        }

        [NotNull]
        public virtual string GetTranslationKey([NotNull] Type translationsType, [NotNull] Enum enumValue)
        {
            if (translationsType == null) throw new ArgumentNullException(nameof(translationsType));
            if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));

            var memberInfo = GetTranslationsMemberInfo(translationsType, enumValue);
            var result = memberInfo.GetKey();
            return result;
        }

        [NotNull]
        protected virtual ICodeMemberInfo GetTranslationsMemberInfo([NotNull] Type translationsType,
            [NotNull] Enum enumValue)
        {
            if (translationsType == null) throw new ArgumentNullException(nameof(translationsType));
            if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));

            var fieldOrPropertyName = enumValue.ToString();
            var memberInfo = CodeMemberInfoFactory.Create(translationsType, fieldOrPropertyName);

            return memberInfo;
        }

        public virtual string Translate<TTranslations>([NotNull] Enum enumValue)
        {
            if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));
            return Translate(typeof (TTranslations), enumValue);
        }
    }
}