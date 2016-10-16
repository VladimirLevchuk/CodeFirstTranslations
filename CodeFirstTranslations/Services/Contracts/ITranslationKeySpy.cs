using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
{
    /// <summary>
    /// Translation key spy analyzes call stack 
    /// to automatically generate translation keys
    /// </summary>
    public interface ITranslationKeySpy
    {
        [NotNull]
        string GenerateTranslationKeyFromCallStack();
    }
}