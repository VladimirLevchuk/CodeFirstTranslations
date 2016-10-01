using CodeFirstTranslations.CodeAnnotations;
using CodeFirstTranslations.Shortcuts;

namespace CodeFirstTranslations.Tests
{
    //public class TranslationService : ITranslationService
    //{
    //    public virtual string Translate(string key)
    //    {
    //        throw new NotImplementedException();
    //    }
    //    public virtual string Translate(string key, string fallback)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public virtual string Text(string)
    //}



    [TranslationClass]
    public partial class Labels
    {
        public static string Label1 => new Translation("");
    }

    public partial class Labels
    {
        public partial class Nested
        {
            public static string NestedLabel => new Translation("");
        }
    }

    public class Messages
    {
        public static string Message1 => new en("en:message1");
        public static string Message2 => new en("en:message2").no("no:message2");
    }

    public enum MyEnum
    {
        None = 0,
        First = 1,
        Second
    }
}
