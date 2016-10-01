namespace CodeFirstTranslations
{
    /// <summary>
    /// Translation key spy analyzes call stack 
    /// to automatically build translatin key
    /// </summary>
    public interface ITranslationKeySpy
    {
        string DiscoverTranslationKeyFromCallStack();
    }
}