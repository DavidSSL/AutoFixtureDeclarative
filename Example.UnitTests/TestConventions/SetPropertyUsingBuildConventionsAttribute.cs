using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

namespace Example.UnitTests.TestConventions
{
    public class SetPropertyUsingBuildConventionsAttribute : AutoDataAttribute
    {
        public SetPropertyUsingBuildConventionsAttribute() :
            base(
            new Fixture().Customize(new SetPropertyUsingBuildConvention()))
        {

        }
    }
}