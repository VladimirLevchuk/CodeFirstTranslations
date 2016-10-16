using CodeFirstTranslations.CodeAnnotations;
using CodeFirstTranslations.Shortcuts;

namespace CodeFirstTranslations.Tests
{
    public class Labels
    {
        public static string Label1 => new StringTranslationProperty("");
    }

    public class Messages
    {
        public static Translation Message1 => new en("en:message1");
        public static Translation Message2 => new en("en:message2").no("no:message2");
    }

    public enum MyEnum
    {
        None = 0,
        First = 1,
        Second
    }
}
