using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

namespace Example.UnitTests.TestConventions
{
    public class BuildArrayConventionsAttribute : AutoDataAttribute
    {
        public BuildArrayConventionsAttribute():base(new Fixture().Customize(new BuildArrayConventions()))
        {
            
        }
    }
}