using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

namespace Example.UnitTests.TestConventions
{
    public class SpecificPopulatedListsTestConventionsAttribute : AutoDataAttribute
    {
        public SpecificPopulatedListsTestConventionsAttribute():base(new Fixture().Customize(new SpecificPopulatedListsTestConventions()))
        {
            
        }
    }
}