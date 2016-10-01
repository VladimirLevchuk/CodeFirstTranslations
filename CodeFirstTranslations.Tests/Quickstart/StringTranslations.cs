using FluentAssertions;
using NUnit.Framework;

namespace CodeFirstTranslations.Tests.Quickstart
{
    public class StringTranslations : TestBase
    {
        public class Translations
        {
            /// <summary>
            /// We can use string type for translation properties
            /// (implicit string conversion for Translation class does this job for us)
            /// </summary>
            public static string Hello = new Translation("Hello", "/texts/hello");

            /// <summary>
            /// When TranslationClasses initialized properly we can use "=" syntax even with auto-generated keys
            /// </summary>
            public static string World = new Translation("World");
        }

        public override void Setup()
        {
            base.Setup();

            TranslationsEnvironment.TranslationClasses.Add<Translations>();
        }

        [Test]
        public void String_Translation_With_Key()
        {
            Translations.Hello.Should().Be("Hello");

            // but we have to play a bit more to get a key for string translation
            // TODO: [normal] register translation keys from Translation ctor, so it's possible to get the key later for string translation
        }

        [Test]
        public void String_Translation_With_Auto_Generated_Key()
        {
            Translations.World.Should().Be("World");

            var codeMemberInfo = TranslationsEnvironment.CodeMemberInfoFactory.Create(typeof(Translations),
                nameof(Translations.World));

            var key = TranslationsEnvironment.TranslationKeyBuilder.BuildTranslationKey(codeMemberInfo);
            key.Should().Be("/translations/world");
        }
    }
}