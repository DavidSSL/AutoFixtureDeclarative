using Examples;
using Ploeh.AutoFixture;
using Xunit;

namespace Example.UnitTests
{
    // Based on http://blog.ploeh.dk/2009/04/23/DealingWithTypesWithoutPublicConstructors/
    public class TypesWithoutPublicCtrsTests
    {
        [Fact]
        public void SomeTest()
        {
            var fixture = new Fixture();

            fixture.Register<IMyInterface>(() => new FakeMyInterface());

            var sut = fixture.Create<TypesWithoutPublicCtrs>();
        }
    }
}