using JetBrains.Annotations;

namespace CodeFirstTranslations.Translations
{
    public class ErrorMessages
    {
        const string KeyPrefix = "/CodeFirstTranslations/ErrorMessages";

        [NotNull]
        public static IFormat2 TranslationMemberNotFound = 
            new TranslationFormat2Field("Translation member '{1}' not found in type '{0}'. ",
                $"{KeyPrefix}/{nameof(TranslationMemberNotFound)}");
        [NotNull]
        public static Translation ErrorGettingTranslation = new TranslationField("Error getting translation. ",
            $"{KeyPrefix}/{nameof(ErrorGettingTranslation)}");
        [NotNull]
        public static Translation UnableToFindKeyFromCurrentStack = new TranslationField(
            "Unable to generate a key for translations. " +
            "Make sure you've added your translations class to Environment.TranslationTypes " +
            "and use expression (=>) syntax or get_ property for your translation member",
            $"{KeyPrefix}/{nameof(UnableToFindKeyFromCurrentStack)}");
        [NotNull]
        public static TranslationFormat1Field TranslationsTypeNotFound = 
            new TranslationFormat1Field("Translations type '{0}' not found. " +
                                        "Make sure you've added it to Environment.TranslationTypes",
                $"{KeyPrefix}/{nameof(TranslationsTypeNotFound)}");

        [NotNull]
        public static Translation NoContext = new TranslationField("No translation context found. Translations configuration is incorrect. ",
            $"{KeyPrefix}/{nameof(NoContext)}");
    }
}