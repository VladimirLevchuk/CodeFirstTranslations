using System.ComponentModel.Design;
using CodeFirstTranslations.CodeAnnotations;
using FluentAssertions;
using NUnit.Framework;

namespace CodeFirstTranslations.Tests.Quickstart
{
    public class StringTranslations : TestBase
    {
        public class Translations
        {
            /// <summary>
            /// When TranslationClasses initialized properly we can use "=" syntax even with auto-generated keys
            /// </summary>
            public static string World => new StringTranslationProperty("World");
        }

        public override void Setup()
        {
            base.Setup();

            TranslationsEnvironment.TranslationClasses.AddRange(new []{typeof(Translations)});
        }

        [Test]
        public void String_Translation_With_Auto_Generated_Key()
        {
            Translations.World.Should().Be("World");
            var key = StringTranslationProperty.GetKey<Translations>(nameof(Translations.World));
            key.Should().Be("/translations/world");
        }
    }
}