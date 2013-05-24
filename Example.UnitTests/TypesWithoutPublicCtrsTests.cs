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

            fixture.Register<int, string, IMyInterface>((i, s) 
                => new FakeMyInterface(i, "This text is anonymous"));

            var sut = fixture.Create<TypesWithoutPublicCtrs>();
        }
    }
}