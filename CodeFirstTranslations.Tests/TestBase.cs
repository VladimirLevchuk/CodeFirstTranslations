using CodeFirstTranslations.Reflection;
using CodeFirstTranslations.Services;
using NUnit.Framework;

namespace CodeFirstTranslations.Tests
{
    public class TestTranslationContext : IReadOnlyTranslationContext
    {
        public ITranslationsEnvironment Environment { get; } = new TestTranslationsEnvironment();
        public string CurrentCulture { get; set; } = "en";
    }

    public class TestTranslationsEnvironment : ITranslationsEnvironment
    {
        public TestTranslationsEnvironment()
        {
            TranslationKeyBuilder = new TranslationKeyGenerator(PathUtil);
            TranslationTypesRegistry = new TranslationTypesRegistry(TestDefaultCulture, TranslationKeyBuilder);
            TranslationKeySpy = new TranslationKeySpy(CodeMemberInfoFactory, TranslationTypesRegistry);
            EnumTranslationService = new EnumTranslationService(CodeMemberInfoFactory, TranslationTypesRegistry); 
            KeyGenerator = new TranslationKeyInitializer(CodeMemberInfoFactory, TranslationKeyBuilder);
        }

        const string TestDefaultCulture = "en";

        public IPathUtil PathUtil { get; } = new PathUtil();
        public ITranslationKeyInitializer KeyGenerator { get; } 
        public ICodeMemberInfoFactory CodeMemberInfoFactory { get; } = new CodeMemberFactory();
        public ITranslationKeySpy TranslationKeySpy { get; } 
        public ITranslationService TranslationService { get; set; } = new ReturnFallbackTransationService();
        public ITranslationTypesRegistry TranslationTypesRegistry { get; }
        public ITranslationKeyGenerator TranslationKeyBuilder { get; }
        public ICodeMemberKeyBuilder CodeMemberKeyBuilder { get; } = new CodeMemberKeyBuilder();
        public IEnumTranslationService EnumTranslationService { get; } 
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