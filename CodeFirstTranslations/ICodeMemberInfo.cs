using System;
using System.Collections.Generic;

namespace Creuna.CodeFirstTranslations2
{
    public interface ICodeMemberInfo
    {
        Type Type { get; }
        string Name { get; }
        string DefaultPropertyPath { get; }
        string DefaultTypePath { get; } 
        string MemberId { get; }

        List<TAnnotation> GetTypeAnnotations<TAnnotation>();
        List<TAnnotation> GetMemberAnnotations<TAnnotation>();
    }
}