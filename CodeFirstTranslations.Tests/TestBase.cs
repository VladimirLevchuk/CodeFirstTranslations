using CodeFirstTranslations.Services;
using NUnit.Framework;

namespace CodeFirstTranslations.Tests
{
    public class TestTranslationContext : IReadOnlyTranslationContext
    {
        public ITranslationsEnvironment Environment { get; } = new TestTranslationsEnvironment();
        public string CurrentCulture { get; set; }
    }

    public class TestTranslationsEnvironment : ITranslationsEnvironment
    {
        public TestTranslationsEnvironment()
        {
            TranslationKeySpy = new TranslationKeySpy(CodeMemberInfoFactory);
        }

        const string TestDefaultCulture = "en";

        public ICodeMemberInfoFactory CodeMemberInfoFactory { get; set; } = new CodeMemberFactory();
        public ITranslationKeySpy TranslationKeySpy { get; set; } 
        public ITranslationService TranslationService { get; set; } = new ReturnFallbackTransationService();
        public ITranslationClasses TranslationClasses { get; set; } = new TranslationClasses(TestDefaultCulture);
        public ITranslationKeyBuilder TranslationKeyBuilder { get; set; } = new TranslationKeyBuilder();
        public ICodeMemberKeyBuilder CodeMemberKeyBuilder { get; set; } = new CodeMemberKeyBuilder();
        
        public IPathUtil PathUtil { get; } = new PathUtil();
        public IPathOverrides PathOverrides => null;
    }

    public class ReturnFallbackTransationService : ITranslationService
    {
        public virtual string Translate(string key, string fallback)
        {
            return fallback;
        }
    }

    public class ReturnKeyTransationService : ITranslationService
    {
        public virtual string Translate(string key, string fallback)
        {
            return key;
        }
    }

    public class TestBase
    {
        [SetUp]
        public virtual void Setup()
        {
            this.TranslationContext = new TestTranslationContext();
            CodeFirstTranslations.TranslationContext.ContextAccessor = () => TranslationContext;
        }

        [TearDown]
        public virtual void Cleanup()
        {
            this.TranslationContext = null;
        }

        protected TestTranslationContext TranslationContext { get; set; }

        protected TestTranslationsEnvironment TranslationsEnvironment => (TestTranslationsEnvironment) TranslationContext?.Environment;
    }
}