using System;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Services
{
    public interface IEnumTranslationService
    {
        string Translate([NotNull] Enum enumValue);
        string Translate([NotNull] Type translationsType, [NotNull] Enum enumValue);
        string Translate<TTranslations>([NotNull] Enum enumValue);
    }
}