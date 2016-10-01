namespace CodeFirstTranslations.Translations
{
    public class ErrorMessages
    {
        const string KeyPrefix = "/CodeFirstTranslations/ErrorMessages";

        public static TranslationFormat2 TranslationPropertyNotFound = 
            new TranslationFormat2("Translation property '{1}' not found in type '{0}'. ",
                $"{KeyPrefix}/TranslationPropertyNotFound");
        public static Translation ErrorGettingTranslation = new TranslationWithKey("Error getting translation. ",
            $"{KeyPrefix}/ErrorGettingTranslation");
        public static Translation UnableToFindKeyFromCurrentStack = new TranslationWithKey(
            "Unable to generate a key for translations. Make sure you've added your translations class to Environment.TranslationClasses",
            $"{KeyPrefix}/UnableToFindKeyFromCurrentStack");
    }
}