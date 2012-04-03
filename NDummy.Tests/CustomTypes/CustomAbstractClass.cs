namespace NDummy.Tests.CustomTypes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public abstract class CustomAbstractClass
    {
        public abstract string AbstractClassID { get; set; }
    }

    public class CustomAbstractClassImpl : CustomAbstractClass
    {
        public override string AbstractClassID { get; set; }
    }
}
