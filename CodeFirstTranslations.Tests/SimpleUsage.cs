using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Creuna.CodeFirstTranslations2.Tests
{
    public class TestTranslationContext : IReadOnlyTranslationContext, IWriteOnlyTranslationContext
    {
        public ITranslationsEnvironment Environment { get; } = new TestTranslationsEnvironment();
        public string CurrentCulture { get; set; }
    }

    public class TestTranslationsEnvironment : ITranslationsEnvironment
    {
        const string TestDefaultCulture = "en";

        public ITranslationKeySpy TranslationKeySpy => new TranslationKeySpy();
        public ITranslationService TranslationService => new TestTransationService();
        public TranslationClasses TranslationClasses { get; } = new TranslationClasses(TestDefaultCulture);
    }

    public class TestTransationService : ITranslationService
    {
        //public virtual string Translate(string key)
        //{
        //    return $"{TranslationContext.Current.CurrentCulture}:{key}";
        //}

        public virtual string Translate(string key, string fallback)
        {
            return fallback;
        }
    }

    public class TestBase
    {
        [SetUp]
        public virtual void Setup()
        {
            TranslationContext.Current = new TestTranslationContext();
        }
    }


    public class SimpleUsage
    {
        [SetUp]
        public void Setup()
        {
            //var service = Substitute.For<ITranslationService>();
            //service.Translate(Arg.Any<string>()).Returns(x => x[0].As<string>());
            //service.Translate(Arg.Any<string>(), Arg.Any<string>()).Returns(x => x[1].As<string>());
        }

        [Test]
        public void KeyFromCallStack()
        {
            Labels.Label1.Should().Be("/labels/label1");
            Labels.Nested.NestedLabel.Should().Be("/labels/nested/label1");
        }
    }
}