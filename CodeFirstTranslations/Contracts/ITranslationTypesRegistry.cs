using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace CodeFirstTranslations
{
    /// <summary>
    /// Translation types registry. 
    /// User to automatically generate translation keys. 
    /// </summary>
    public interface ITranslationTypesRegistry
    {
        /// <summary>
        /// Returns a default culture code-first translations defined for
        /// </summary>
        string DefaultCulture { get; }

        /// <summary>
        /// Registers a translation type 
        /// </summary>
        /// <typeparam name="TTranslations">Translations type</typeparam>
        /// <param name="classPath">class part of the translation key. By default is auto-generated</param>
        /// <returns></returns>
        [NotNull]
        ITranslationTypesRegistry Add<TTranslations>([CanBeNull] string classPath = null);
        /// <summary>
        /// Registers a translation type 
        /// </summary>
        /// <param name="translationsType">Translations type</param>
        /// <param name="classPath">class part of the translation key. By default is auto-generated</param>
        /// <returns></returns>
        [NotNull]
        ITranslationTypesRegistry Add([NotNull] Type translationsType, [CanBeNull] string classPath = null);
        /// <summary>
        /// Register a translation type TTranslations as a translations for enum TEnum
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        /// <typeparam name="TTranslations">Translations type</typeparam>
        /// <param name="classPath">Class part of the translation key. By default is auto-generated</param>
        /// <returns></returns>
        [NotNull]
        ITranslationTypesRegistry AddEnum<TEnum, TTranslations>([CanBeNull] string classPath = null);
        /// <summary>
        /// Register a translation type TTranslations as a translations for enum TEnum
        /// </summary>
        /// <param name="enumType">Enum type</param>
        /// <param name="translationsType">Translations type</param>
        /// <param name="classPath">Class part of the translation key. By default is auto-generated</param>
        /// <returns></returns>
        [NotNull]
        ITranslationTypesRegistry AddEnum([NotNull] Type enumType, [NotNull] Type translationsType, [CanBeNull] string classPath = null);
        /// <summary>
        /// Registers translation types with auto-generated paths
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        [NotNull]
        ITranslationTypesRegistry AddRange([NotNull] IEnumerable<Type> types);
        /// <summary>
        /// Registers translation types
        /// </summary>
        /// <param name="typeInfos"></param>
        /// <returns></returns>
        [NotNull]
        ITranslationTypesRegistry AddRange([NotNull] IEnumerable<TranslationTypeInfo> typeInfos);

        /// <summary>
        /// Returns list of translation types
        /// </summary>
        /// <returns></returns>
        [NotNull]
        IList<TranslationTypeInfo> ToList();
        /// <summary>
        /// Returns true if the given type is registered
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        bool Contains([NotNull] Type type);

        [CanBeNull]
        string TryGetTypePath([NotNull] Type type);
        [NotNull]
        string GetTypePath([NotNull] Type translationsType);
        [NotNull]
        Type GetEnumTranslationsType([NotNull] Type enumType);
    }
}