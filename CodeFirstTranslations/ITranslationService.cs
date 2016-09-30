namespace Creuna.CodeFirstTranslations2
{
    public interface ITranslationService
    {
        // string Translate(string key);
        string Translate(string key, string fallback);
    }
}