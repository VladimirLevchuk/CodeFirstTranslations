using FluentAssertions;
using NUnit.Framework;

namespace CodeFirstTranslations.Tests
{
    public class SimpleUsage : TestBase
    {




        [Test]
        public void TwoCultures()
        {
            TranslationContext.Environment.TranslationClasses
                .Add<Messages>();

            TranslationContext.CurrentCulture = "en";
            Messages.Message2.Should().Be("en:message2");

            TranslationContext.CurrentCulture = "no";
            Messages.Message2.Should().Be("no:message2");

            TranslationContext.CurrentCulture = "fr";
            Messages.Message2.Should().Be("en:message2");
        }
    }
}