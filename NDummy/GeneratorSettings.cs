namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    public class GeneratorSettings : Settings, IGeneratorSettings
    {
        private readonly IDictionary<MemberInfo, object> memberFactories;

        private readonly IList<object> customActions;

        public GeneratorSettings()
        {
            memberFactories = new Dictionary<MemberInfo, object>();
            customActions = new List<object>(); 
        }

        public void SetMemberFactory(MemberInfo memberInfo, object factory)
        {
            if (memberFactories.ContainsKey(memberInfo))
                memberFactories[memberInfo] = factory;
            else
                memberFactories.Add(memberInfo, factory);
        }

        public IDictionary<MemberInfo, object> MemberFactories
        {
            get
            {
                return memberFactories;
            }
        }

        public void AddCustomAction(object customAction)
        {
            customActions.Add(customAction);
        }

        public IList<object> CustomActions
        {
            get
            {
                return customActions;
            }
        }
    }
}
