using System.Collections.Generic;

namespace Creuna.CodeFirstTranslations2
{
    public interface IPathOverrides
    {
        IDictionary<string, string> ClassPathOverrides { get; }
        IDictionary<string, string> MemberPathOverrides { get; }
    }
}