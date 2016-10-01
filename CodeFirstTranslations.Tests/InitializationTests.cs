using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CodeFirstTranslations.Tests
{
    public class InitializationTests
    {
        [Test]
        public void DefaultCutlure()
        {
            var translations = new TranslationClasses("en");

            translations.DefaultCulture.Should().Be("en");
        }

        [Test]
        public void FluentEnumerating()
        {
            var translations = new TranslationClasses("en");

            translations
                .Add<Labels>()
                .Add<Messages>()
                .Add<MyEnum>();

            translations.ToList().Select(x => x.Name)
                .Should().BeEquivalentTo("Labels", "Messages", "MyEnum");
        }

        [Test]
        public void Enumerating()
        {
            var translations = new TranslationClasses("en");

            translations
                .AddRange(new [] { typeof(Labels), typeof(Messages), typeof(MyEnum) } );

            translations.ToList().Select(x => x.Name)
                .Should().BeEquivalentTo("Labels", "Messages", "MyEnum");
        }

        // V2 - scanning
        //[Test]
        //public void Scanning()
        //{
        //    var translations = new Translations("en");

        //    translations.Scan(Assembly.GetExecutingAssembly()); // use custom attribute

        //    translations.GetTranslationClasses().Select(x => x.Name)
        //        .Should().BeEquivalentTo("Labels", "Messages", "MyEnum");

        //}
    }
}