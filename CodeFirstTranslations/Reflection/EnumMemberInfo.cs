using System;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;

namespace CodeFirstTranslations.Reflection
{
    public class EnumMemberInfo : CodeMemberInfo
    {
        public EnumMemberInfo([NotNull] Type type, [NotNull] string name) : base(type, name)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (name == null) throw new ArgumentNullException(nameof(name));
        }

        protected override ITranslation TryGetTranslation()
        {
            throw new NotImplementedException();
        }

        public override MemberInfo MemberInfo
        {
            get
            {
                // TODO [high] implement EnumMemberInfo.MemberInfo
                throw new NotImplementedException();
            }
        }
    }
}