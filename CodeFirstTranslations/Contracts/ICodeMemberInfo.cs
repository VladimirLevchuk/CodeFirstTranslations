using System;
using System.Collections.Generic;

namespace CodeFirstTranslations
{
    /// <summary>
    /// Information about code member
    /// </summary>
    public interface ICodeMemberInfo
    {
        /// <summary>
        /// Type where member is present
        /// </summary>
        Type Type { get; }
        /// <summary>
        /// Member name
        /// </summary>
        string Name { get; }
        /// <summary>
        /// 
        /// </summary>
        string DefaultPropertyPath { get; }
        string DefaultTypePath { get; } 
        string MemberId { get; }

        List<TAnnotation> GetTypeAnnotations<TAnnotation>();
        List<TAnnotation> GetMemberAnnotations<TAnnotation>();
    }
}