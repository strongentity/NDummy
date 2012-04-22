namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public interface INeedMemberInfo
    {
        MemberInfo MemberInfo { get; set; }
    }
}
