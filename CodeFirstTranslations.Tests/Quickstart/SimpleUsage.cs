using FluentAssertions;
using NUnit.Framework;

namespace CodeFirstTranslations.Tests.Quickstart
{
    public class SimpleUsage : TestBase
    {
        [Test]
        public void TwoCultures()
        {
            TranslationContext.Environment.TranslationTypesRegistry
                .Add<Messages>();

            TranslationContext.CurrentCulture = "en";
            Messages.Message2.ToString().Should().Be("en:message2");

            TranslationContext.CurrentCulture = "no";
            Messages.Message2.ToString().Should().Be("no:message2");

            TranslationContext.CurrentCulture = "fr";
            Messages.Message2.ToString().Should().Be("en:message2");
        }
    }
}