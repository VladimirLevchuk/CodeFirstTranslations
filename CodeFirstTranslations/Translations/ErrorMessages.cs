namespace CodeFirstTranslations.Translations
{
    public class ErrorMessages
    {
        const string KeyPrefix = "/CodeFirstTranslations/ErrorMessages";

        public static IFormat2 TranslationPropertyNotFound = 
            new TranslationFormat2Field("Translation property '{1}' not found in type '{0}'. ",
                $"{KeyPrefix}/TranslationPropertyNotFound");
        public static Translation ErrorGettingTranslation = new TranslationField("Error getting translation. ",
            $"{KeyPrefix}/ErrorGettingTranslation");
        public static Translation UnableToFindKeyFromCurrentStack = new TranslationField(
            "Unable to generate a key for translations. " +
            "Make sure you've added your translations class to Environment.TranslationClasses " +
            "and use expression (=>) syntax or get_ property for your translation member",
            $"{KeyPrefix}/UnableToFindKeyFromCurrentStack");
    }
}