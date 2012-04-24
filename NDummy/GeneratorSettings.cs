namespace NDummy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    public class GeneratorSettings : Settings, IGeneratorSettings
    {
        private readonly IDictionary<MemberInfo, IFactory> memberFactories;

        private readonly IList<object> customActions;

        public GeneratorSettings()
        {
            memberFactories = new Dictionary<MemberInfo, IFactory>();
            customActions = new List<object>(); 
        }

        public void SetMemberFactory(MemberInfo memberInfo, IFactory factory)
        {
            if (memberFactories.ContainsKey(memberInfo))
                memberFactories[memberInfo] = factory;
            else
                memberFactories.Add(memberInfo, factory);
        }

        public IDictionary<MemberInfo, IFactory> MemberFactories
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

        public bool OverrideChildSettings { get; set; }

        public void Apply(IGeneratorSettings settings)
        {
            foreach (var pair in settings.Factories)
            {
                SetFactory(pair.Key, pair.Value);
            }

            foreach (var pair in settings.MemberFactories)
            {
                this.SetMemberFactory(pair.Key, pair.Value); 
            }

            foreach(var action in settings.CustomActions)
            {
                this.AddCustomAction(action);
            }

            this.MaxDepth = settings.MaxDepth;
            this.OverrideChildSettings = settings.OverrideChildSettings;
        }
    }
}
