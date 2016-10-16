using System;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
{
    public interface IEnumTranslationService
    {
        [CanBeNull]
        string Translate([NotNull] Enum enumValue);
        [CanBeNull]
        string Translate([NotNull] Type translationsType, [NotNull] Enum enumValue);
        [CanBeNull]
        string Translate<TTranslations>([NotNull] Enum enumValue);

        [NotNull]
        string GetTranslationKey([NotNull] Type translationsType, [NotNull] Enum enumValue);
    }
}