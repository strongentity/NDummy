namespace NDummy
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;

    using NDummy.Factories;

    public class DefaultSettings : Settings
    {
        public DefaultSettings()
        {
            //SetFactory<bool>(new );
            SetFactory<byte>(new RandomByteFactory());
            SetFactory(new RandomSByteFactory());
            SetFactory(new RandomInt16Factory());
            SetFactory(new RandomUInt16Factory());
            SetFactory(new RandomInt32Factory());
            SetFactory(new RandomUInt32Factory());
            SetFactory(new RandomInt64Factory());
            SetFactory(new RandomUInt64Factory());

            //TODO add more types

        }
    }
}
