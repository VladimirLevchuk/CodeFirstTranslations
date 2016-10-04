using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Reflection
{
    /// <summary>
    /// Information about code member
    /// </summary>
    public interface ICodeMemberInfo
    {
        /// <summary>
        /// Type where member is present
        /// </summary>
        [NotNull]
        Type Type { get; }
        /// <summary>
        /// Member name
        /// </summary>
        [NotNull]
        string Name { get; }

        [NotNull]
        string DefaultPropertyPath { get; }
        [NotNull]
        string MemberKey { get; }

        [NotNull]
        List<TAnnotation> GetMemberAnnotations<TAnnotation>();
    }
}