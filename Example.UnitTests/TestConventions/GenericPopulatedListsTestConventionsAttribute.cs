using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

namespace Example.UnitTests.TestConventions
{
    internal class GenericPopulatedListsTestConventionsAttribute : AutoDataAttribute
    {
        public GenericPopulatedListsTestConventionsAttribute():base(new Fixture().Customize(new GenericPopulatedListsTestConventions()))
        {
            
        }
    }
}