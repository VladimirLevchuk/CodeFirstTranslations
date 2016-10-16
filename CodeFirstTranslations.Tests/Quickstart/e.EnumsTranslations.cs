using FluentAssertions;
using NUnit.Framework;

namespace CodeFirstTranslations.Tests.Quickstart
{
    public class EnumsTranslations : TestBase
    {
        public enum MyEnum
        {
            One, Two, Three
        }

        public class MyEnumTanslations1
        {
            public static Translation One = new TranslationField("One");
            public static Translation Two = new TranslationField("Two");
            public static Translation Three = new TranslationField("Three");
        }

        public class MyEnumTanslations2
        {
            public static Translation One = new TranslationField("One2");
            public static Translation Two = new TranslationField("Two2");
            public static Translation Three = new TranslationField("Three2");
        }

        [Test]
        public void Enum_Translation()
        {
            // the following string configures default translation for enum
            TranslationsEnvironment.TranslationTypesRegistry.AddEnum<MyEnum, MyEnumTanslations1>();

            TranslationsEnvironment.KeyGenerator.AutoGenerateMissedKeys(TranslationsEnvironment.TranslationTypesRegistry);

            // and Enum.Translate is a shortcut for TranslationEnvironment.EnumTranslationService.Translate
            Enums.Translate(MyEnum.One).Should().Be("One");
        }

        [Test]
        public void Enum_Alternative_Translation()
        {
            TranslationsEnvironment.TranslationTypesRegistry.AddEnum<MyEnum, MyEnumTanslations1>();
            TranslationsEnvironment.TranslationTypesRegistry.Add<MyEnumTanslations2>();

            TranslationsEnvironment.KeyGenerator.AutoGenerateMissedKeys(TranslationsEnvironment.TranslationTypesRegistry);

            // alternative translation gets translation from the given type
            Enums.Translate<MyEnumTanslations2>(MyEnum.One).Should().Be("One2");
            // while default one should still work
            Enums.Translate(MyEnum.One).Should().Be("One");
        }
    }
}