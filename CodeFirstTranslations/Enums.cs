using System;

namespace CodeFirstTranslations
{
    public static class Enums
    {
        public static string Translate(Enum enumValue)
        {
            return TranslationContext.Current.Environment.EnumTranslationService.Translate(enumValue);
        }

        public static string Translate(Type translationsType, Enum enumValue)
        {
            return TranslationContext.Current.Environment.EnumTranslationService.Translate(translationsType, enumValue);
        }

        public static string Translate<TTranslations>(Enum enumValue)
        {
            return TranslationContext.Current.Environment.EnumTranslationService.Translate<TTranslations>(enumValue);
        }
    }
}