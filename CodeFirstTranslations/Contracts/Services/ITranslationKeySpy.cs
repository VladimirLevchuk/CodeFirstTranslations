namespace CodeFirstTranslations
{
    /// <summary>
    /// Translation key spy analyzes call stack 
    /// to automatically generate translation keys
    /// </summary>
    public interface ITranslationKeySpy
    {
        string GenerateTranslationKeyFromCallStack();
    }
}