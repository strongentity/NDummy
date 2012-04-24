namespace NDummy.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    /// <summary>
    /// Provides a way to generate string
    /// </summary>
    public class StringFactory : IFactory<string>, INeedMemberInfo
    {
        private readonly string delimiter;

        private readonly string prefix;

        private readonly string suffix;

        private readonly IFactory<int> factory;

        /// <summary>
        /// Initializes a new instance of the <see cref="StringFactory"/> class.
        /// </summary>
        public StringFactory():this(new StringFactorySettings
            {
                Delimiter = " ",
                Prefix = string.Empty,
                Suffix = string.Empty
            })
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StringFactory"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public StringFactory(StringFactorySettings settings)
        {
           if(settings == null)
               throw new ArgumentNullException();

            prefix = settings.Prefix;
            delimiter = settings.Delimiter;
            suffix = settings.Suffix;

            if(settings.IsRandom)
                factory = new RandomInt32Factory();
            else
                factory = new Int32SequenceFactory();

        }

        /// <summary>
        /// Gets or sets the member info.
        /// </summary>
        /// <value>
        /// The member info.
        /// </value>
        public MemberInfo MemberInfo { get; set; }

        /// <summary>
        /// Generates string instance.
        /// </summary>
        /// <returns>New string instance</returns>
        public string Generate()
        {
            string memberName = MemberInfo != null ? MemberInfo.Name : string.Empty;

            return string.Format("{0}{1}{2}{3}{4}", prefix, memberName, delimiter, factory.Generate(), suffix);
        }

        /// <summary>
        /// Generates string instance.
        /// </summary>
        /// <returns>New string instance</returns>
        object IFactory.Generate()
        {
            return this.Generate();
        }
    }

    /// <summary>
    /// Represents information needed for StringFactory class
    /// </summary>
    public class StringFactorySettings
    {
        /// <summary>
        /// Gets or sets the delimiter.
        /// </summary>
        /// <value>
        /// The delimiter.
        /// </value>
        public string Delimiter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is random.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is random; otherwise, <c>false</c>.
        /// </value>
        public bool IsRandom { get; set; }

        /// <summary>
        /// Gets or sets the prefix.
        /// </summary>
        /// <value>
        /// The prefix.
        /// </value>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets or sets the suffix.
        /// </summary>
        /// <value>
        /// The suffix.
        /// </value>
        public string Suffix { get; set; }
    }
}
