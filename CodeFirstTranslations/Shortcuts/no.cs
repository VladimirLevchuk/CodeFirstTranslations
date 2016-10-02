namespace CodeFirstTranslations.Shortcuts
{
    public class no : TranslationProperty
    {
        public no(string text) : base(text)
        {
            this.AddTranslation("no", text);
        }
    }
}