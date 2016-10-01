namespace CodeFirstTranslations.Services
{
    public class TranslationKeyBuilder : ITranslationKeyBuilder
    {
        public virtual string BuildTranslationKey(ICodeMemberInfo codeMember)
        {
            return $"/{codeMember.Type.Name}/{codeMember.Name}".ToLowerInvariant();
        }
    }
}