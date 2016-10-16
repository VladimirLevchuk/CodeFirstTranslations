using System;
using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace CodeFirstTranslations.Tests.Performance
{
    public abstract class PerformanceTestBase : TestBase
    {
        public override void Setup()
        {
            base.Setup();
            SetupTranslations(TranslationsEnvironment.TranslationTypesRegistry);
            this.Stopwatch = new Stopwatch();
            Stopwatch.Start();
        }

        protected abstract void SetupTranslations(ITranslationTypesRegistry translationTypesRegistry);

        public Stopwatch Stopwatch { get; set; }

        public override void Cleanup()
        {
            base.Cleanup();
            Stopwatch.Stop();
            Console.WriteLine($"Execution time: {Stopwatch.Elapsed} ({Stopwatch.ElapsedMilliseconds} ms)");
        }
    }

    public class StringPropertyVsFieldPerformanceCompare : PerformanceTestBase
    {
        // const int NumberOfTranslations = 1000000; // 12.677 vs 0.091 

        // const int NumberOfTranslations = 100000; // 1.342 vs 0.021 sec

        const int NumberOfTranslations = 10000; // 0.137 vs 0.014 sec

        /// <summary>
        /// For 1000 translations performance is almost equal
        /// </summary>
        // const int NumberOfTranslations = 1000; // 0.018 vs 0.013 sec

        protected override void SetupTranslations(ITranslationTypesRegistry translationTypesRegistry)
        {
            TranslationsEnvironment.TranslationTypesRegistry.Add<Translations>();
        }

        public class Translations
        {
            public static string Property => new StringTranslationProperty("translation");

            public static Translation Field = new TranslationField<Translations>(nameof(Field), "translation");
        }

        [Test]
        public void PropertyTranslations1()
        {
            for (int i = 0; i < NumberOfTranslations; ++i)
            {
                var t = Translations.Property;
            }
        }

        [Test]
        public void FieldTranslations1()
        {
            for (int i = 0; i < NumberOfTranslations; ++i)
            {
                var t = Translations.Field.ToString();
            }
        }
    }
}