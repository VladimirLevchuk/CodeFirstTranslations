using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using CodeFirstTranslations.Reflection;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
{
    public class EnumTranslationService : IEnumTranslationService
    {
        public EnumTranslationService([NotNull] ICodeMemberInfoFactory codeMemberInfoFactory,
            [NotNull] ICodeMemberKeyBuilder codeMemberKeyBuilder, [NotNull] ITranslationService translationService)
        {
            if (codeMemberInfoFactory == null) throw new ArgumentNullException(nameof(codeMemberInfoFactory));
            if (codeMemberKeyBuilder == null) throw new ArgumentNullException(nameof(codeMemberKeyBuilder));
            if (translationService == null) throw new ArgumentNullException(nameof(translationService));

            CodeMemberInfoFactory = codeMemberInfoFactory;
            CodeMemberKeyBuilder = codeMemberKeyBuilder;
            TranslationService = translationService;
        }

        [NotNull]
        protected ICodeMemberInfoFactory CodeMemberInfoFactory { get; }
        [NotNull]
        protected ICodeMemberKeyBuilder CodeMemberKeyBuilder { get; }
        [NotNull]
        public ITranslationService TranslationService { get; }

        public virtual string Translate(Enum enumValue)
        {
            throw new NotImplementedException();
        }

        public virtual string Translate([NotNull] Type translationsType, [NotNull] Enum enumValue)
        {
            if (translationsType == null) throw new ArgumentNullException(nameof(translationsType));
            if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));

            var fieldOrPropertyName = enumValue.ToString();
            var memberInfo = CodeMemberInfoFactory.Create(translationsType, fieldOrPropertyName);
            var key = CodeMemberKeyBuilder.BuildMemberKey(memberInfo);
            var result = TranslationService.Translate()

        }

        public virtual string Translate<TTranslations>([NotNull] Enum enumValue)
        {
            if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));
            return Translate(typeof (TTranslations), enumValue);
        }
    }
}