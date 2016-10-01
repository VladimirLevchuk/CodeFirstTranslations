namespace CodeFirstTranslations.Shortcuts
{
    public static class TranslationExtensions
    {
        public static Translation no(this Translation translation, string text)
        {
            return translation.AddTranslation("no", text);
        }
        public static Translation en(this Translation translation, string text)
        {
            return translation.AddTranslation("en", text);
        }
    }
}