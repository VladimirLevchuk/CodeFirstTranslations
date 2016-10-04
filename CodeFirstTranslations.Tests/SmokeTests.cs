using FluentAssertions;
using NUnit.Framework;

namespace CodeFirstTranslations.Tests
{
    public class SmokeTests : TestBase
    {
        [Test]
        public void KeyFromCallStack()
        {
            TranslationContext.Environment.TranslationTypesRegistry
                .Add<Labels>();

            TranslationsEnvironment.TranslationService = new ReturnKeyTransationService();

            Labels.Label1.Should().Be("/labels/label1");
        }
    }
}