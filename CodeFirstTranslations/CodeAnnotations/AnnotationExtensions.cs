using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace CodeFirstTranslations.CodeAnnotations
{
    public static class AnnotationExtensions
    {
        [NotNull]
        public static List<TAttribute> GetAnnotations<TAttribute>([NotNull] this MemberInfo memberInfo, bool inherit = true)
        {
            if (memberInfo == null) throw new ArgumentNullException(nameof(memberInfo));
            var result = memberInfo.GetCustomAttributes(inherit).OrEmpty().OfType<TAttribute>().ToList();
            return result;
        }
    }
}