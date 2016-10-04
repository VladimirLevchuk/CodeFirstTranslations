using NUnit.Framework;

namespace CodeFirstTranslations.Tests.Performance
{
    public class TypedPropertyVsFieldPerformaceCompare : PerformanceTestBase
    {
        protected override void SetupTranslations(ITranslationTypesRegistry translationTypesRegistry)
        {
            TranslationsEnvironment.TranslationTypesRegistry.Add<Translations>();
        }

        public class Translations
        {
            public static Translation Property => new TranslationProperty("translation");

            public static Translation Field = new TranslationField<Translations>(nameof(Field), "translation");
        }

        const int NumberOfTranslations = 100000;

        [Test]
        public void PropertyTranslations()
        {
            for (int i = 0; i < NumberOfTranslations; ++i)
            {
                var t = Translations.Property.ToString();
            }
        }

        [Test]
        public void FieldTranslations()
        {
            for (int i = 0; i < NumberOfTranslations; ++i)
            {
                var t = Translations.Field.ToString();
            }
        }
    }
}