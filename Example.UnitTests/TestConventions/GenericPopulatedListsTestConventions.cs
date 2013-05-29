using Ploeh.AutoFixture;

namespace Example.UnitTests.TestConventions
{
    internal class GenericPopulatedListsTestConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize(new MultipleCustomization());
        }
    }
}