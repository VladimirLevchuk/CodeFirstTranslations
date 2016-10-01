namespace CodeFirstTranslations.Shortcuts
{
    public class en : Translation
    {
        public en(string text) : base(text)
        {
            this.AddTranslation("en", text);
        }
    }
}