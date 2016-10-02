namespace CodeFirstTranslations.Shortcuts
{
    public class en : TranslationProperty
    {
        public en(string text) : base(text)
        {
            this.AddTranslation("en", text);
        }
    }
}