using System;
using System.Collections.Generic;

namespace CodeFirstTranslations
{
    public class EnumMemberInfo : CodeMemberInfo
    {
        public EnumMemberInfo(Type type, string name) : base(type, name)
        {
        }

        public override List<TAnnotation> GetMemberAnnotations<TAnnotation>()
        {
            // TODO [high] implement EnumMemberInfo.GetMemberAnnotations
            throw new NotImplementedException();
        }
    }
}