using System.Linq;
using Ploeh.AutoFixture;

namespace Example.UnitTests.TestConventions
{
    public class SpecificPopulatedListsTestConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Register(() =>
                             fixture.CreateMany<int>().ToList());
        }
    }
}