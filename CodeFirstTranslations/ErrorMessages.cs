using Creuna.CodeFirstTranslations2.CodeAnnotations;

namespace Creuna.CodeFirstTranslations2
{
    [TranslationClass(Path = "/CodeFirstTranslations/ErrorMessages")]
    public class ErrorMessages
    {
        public static string TranslationPropertyNotFound_Format2 => new T("Translation property '{1}' not found in type '{0}'. ");
        public static string ErrorGettingTranslation => new T("Error getting translation. ");
        public static string UnableToFindKeyFromCurrentStack => new T("Unable to find ket from the current call stack. ");
    }
}