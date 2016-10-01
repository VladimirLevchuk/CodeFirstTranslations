using System.Collections.Generic;

namespace CodeFirstTranslations
{
    /// <summary>
    /// Can be used to customize key generation for custom classes. 
    /// By default key consists of 2 parts combined using IPathUtil:
    /// {classPath} + {memberPath}. 
    /// IPathOverrides can be used to customize paths from the code
    /// even when translations are in external assembly.  
    /// </summary>
    public interface IPathOverrides
    {
        /// <summary>
        /// Translations class full name => path used for the class
        /// </summary>
        IDictionary<string, string> ClassPathOverrides { get; }
        /// <summary>
        /// Member key (see ICodeMemberKeyBuilder) => member path
        /// </summary>
        IDictionary<string, string> MemberPathOverrides { get; }
    }
}