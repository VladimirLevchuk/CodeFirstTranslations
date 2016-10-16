using System;
using CodeFirstTranslations.Services;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    public static class Enums
    {
        private static IEnumTranslationService EnumTranslationService => TranslationContext.Current.Environment.EnumTranslationService;

        [CanBeNull]
        public static string Translate([NotNull] Enum enumValue)
        {
            if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));
            return EnumTranslationService.Translate(enumValue);
        }
        
        [CanBeNull]
        public static string Translate([NotNull] Type translationsType, [NotNull] Enum enumValue)
        {
            if (translationsType == null) throw new ArgumentNullException(nameof(translationsType));
            if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));

            return EnumTranslationService.Translate(translationsType, enumValue);
        }

        [CanBeNull]
        public static string Translate<TTranslations>([NotNull] Enum enumValue)
        {
            if (enumValue == null) throw new ArgumentNullException(nameof(enumValue));

            return EnumTranslationService.Translate<TTranslations>(enumValue);
        }
    }
}