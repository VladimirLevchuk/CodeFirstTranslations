using System;
using System.Collections.Generic;

namespace CodeFirstTranslations
{
    /// <summary>
    /// Translation classes registry. 
    /// User to automatically discover translation keys. 
    /// </summary>
    public interface ITranslationClasses
    {
        ITranslationClasses Add<TTranslationClass>();
        ITranslationClasses AddRange(IEnumerable<Type> types);

        string DefaultCulture { get; }
        List<Type> ToList();
        bool Contains(Type type);
    }
}