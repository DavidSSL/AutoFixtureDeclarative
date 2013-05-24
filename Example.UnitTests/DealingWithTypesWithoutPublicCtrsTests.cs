using Examples;
using FluentAssertions;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using Ploeh.AutoFixture.Xunit;
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
            var knownText = "This text is not anonymous";
            fixture.Register<int, string, IMyInterface>((i, s) =>
                new FakeMyInterface(i, knownText));
            var sut = fixture.Create<DealingWithTypesWithoutPublicCtrs>();
            // Exercise system
            var result = sut.Echo("test");
            // Verify outcome
            result.Should().Be("test");
            // Teardown
        }

        [Theory, AutoData]
        public void DeclarativeStyleOneOff(
            [Frozen(As = typeof(IMyInterface))]FakeMyInterface dummy
            , DealingWithTypesWithoutPublicCtrs sut)
        {
            var result = sut.Echo("test");
            result.Should().Be("test");
        }

        [Theory, MyTestConventions]
        public void DeclarativeStyleConvention(
            DealingWithTypesWithoutPublicCtrs sut)
        {
            var result = sut.Echo("test");
            result.Should().Be("test");
        }
    }

    public class MyTestConventionsAttribute : AutoDataAttribute
    {
        public MyTestConventionsAttribute() :
            base(new Fixture().Customize(new MyTestConventions()))
        {
        }
    }

    public class MyTestConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(
            new TypeRelay(typeof(IMyInterface), typeof(FakeMyInterface)));
        }
    }
}