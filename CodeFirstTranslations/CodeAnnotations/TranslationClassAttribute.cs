using System;

namespace CodeFirstTranslations.CodeAnnotations
{
    public class TranslationClassAttribute 
        : Attribute, ITranslationsPathProvider
    {
        public string Path { get; set; }
    }
}