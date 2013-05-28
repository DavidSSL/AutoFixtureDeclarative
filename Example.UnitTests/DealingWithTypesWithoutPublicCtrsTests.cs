using Example.UnitTests.TestConventions;
using Examples;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;
using Xunit.Extensions;

namespace Example.UnitTests
{
    // Based on http://blog.ploeh.dk/2009/04/23/DealingWithTypesWithoutPublicConstructors/
    public class DealingWithTypesWithoutPublicCtrsTests
    {
        [Fact]
        public void ImperativeStyle()
        {
            // Fixture setup
            var fixture = new Fixture();
            const string knownText = "This text is not anonymous";
            fixture.Register<int, IMyInterface>((i) =>
                new FakeMyInterface(i, knownText));
            var sut = fixture.Create<DealingWithTypesWithoutPublicCtrs>();
            // Exercise system
            var result = sut.Echo("test");
            // Verify outcome
            result.Should().Be("test");
            // Teardown
        }

        [Theory, MyTestConventions]
        public void DeclarativeStyleConvention(
            DealingWithTypesWithoutPublicCtrs sut)
        {
            var result = sut.Echo("test");
            result.Should().Be("test");
        }
    }
}