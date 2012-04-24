using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NDummy.Factories;
using Xunit.Extensions;

namespace NDummy.Tests.Factories.UniqueFactories
{
    public class Int32UniqueFactoryTest : UniqueFactoryTestBase<int>
    {

      protected override UniqueFactory<int> GetFactory(UniqueFactorySettings<int> settings)
        {
           return settings != null ? new Int32UniqueFactory(settings) : new Int32UniqueFactory();
           // return null;
        }

      [Theory]
      [InlineData(true, 1, 1, 3, 3)]
      public void CheckGeneratedUnique(bool _isRandom,int _maxTry, int _minValue,int _maxValue,int _step)
      {
          CanGenerateRandomResult(_isRandom,_maxTry,_minValue,_maxValue,_step);
      }

    }
}
