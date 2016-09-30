﻿namespace Creuna.CodeFirstTranslations2
{
    public interface ITranslationsEnvironment
    {
        ITranslationKeySpy TranslationKeySpy { get; }
        ITranslationService TranslationService { get; }
        ITranslationClasses TranslationClasses { get; }
        ITranslationKeyBuilder TranslationKeyBuilder { get; }
        ICodeMemberKeyBuilder CodeMemberKeyBuilder { get; }
        ICodeMemberInfoFactory CodeMemberInfoFactory { get; }
        IPathUtil PathUtil { get; }
        IPathOverrides PathOverrides { get; }
    }
}