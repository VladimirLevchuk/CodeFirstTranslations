using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Creuna.CodeFirstTranslations2.CodeAnnotations;

namespace Creuna.CodeFirstTranslations2.Tests
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
        public static string Label1 => new T("");
    }

    public partial class Labels
    {
        public partial class Nested
        {
            public static string NestedLabel => new T("");
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
