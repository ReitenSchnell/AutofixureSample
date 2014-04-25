using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoNSubstitute;
using Ploeh.AutoFixture.Xunit;

namespace AutofixtureSample
{
    public class NSubData : AutoDataAttribute
    {
        public NSubData()
            : base(new Fixture().Customize(new AutoNSubstituteCustomization()))
        {
        }

        public NSubData(int repeatCount)
            : this()
        {
            Fixture.RepeatCount = repeatCount;
        }
    }
}
