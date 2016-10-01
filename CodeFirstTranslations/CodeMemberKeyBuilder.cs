﻿using System;

namespace CodeFirstTranslations
{
    public class CodeMemberKeyBuilder : ICodeMemberKeyBuilder
    {
        public virtual string BuildMemberKey(ICodeMemberInfo codeMemberInfo)
        {
            if (codeMemberInfo == null) throw new ArgumentNullException(nameof(codeMemberInfo));
            return codeMemberInfo.ToString();
        }
    }
}