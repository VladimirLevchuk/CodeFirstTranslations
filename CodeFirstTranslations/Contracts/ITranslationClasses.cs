using System;
using System.Collections.Generic;

namespace CodeFirstTranslations
{
    /// <summary>
    /// Translation classes registry. 
    /// User to automatically generate translation keys. 
    /// </summary>
    public interface ITranslationClasses
    {
        ITranslationClasses Add<TTranslationClass>();
        // ITranslationClasses Add(Type translationClass);
        ITranslationClasses AddRange(IEnumerable<Type> types);

        string DefaultCulture { get; }
        List<Type> ToList();
        bool Contains(Type type);
    }
}