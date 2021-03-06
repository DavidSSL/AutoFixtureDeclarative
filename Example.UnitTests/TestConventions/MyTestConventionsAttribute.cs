using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

namespace Example.UnitTests.TestConventions
{
    public class MyTestConventionsAttribute : AutoDataAttribute
    {
        public MyTestConventionsAttribute() :
            base(new Fixture().Customize(new MyTestConventions()))
        {
        }
    }
}