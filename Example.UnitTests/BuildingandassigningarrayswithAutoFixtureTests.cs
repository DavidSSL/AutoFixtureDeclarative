using System.Linq;
using Examples;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace Example.UnitTests
{
    // Based on http://blog.ploeh.dk/2009/12/05/BuildingandassigningarrayswithAutoFixture/
    public class BuildingAndAssigningArraysWithAutoFixtureTests
    {
        [Fact]
        public void ImperativeStyleSimple()
        {
            // Fixture setup
            var fixture = new Fixture();
            var mc = fixture.Create<MyClassA>();
            mc.Items = fixture.CreateMany<MyClassB>().ToArray();
            // Exercise system
            var result = mc.Echo("test");
            // Verify outcome
            result.Should().Be("test");
            // Fixture teardown
        }

        [Fact]
        public void ImperativeStyleWithBuild()
        {
            // Fixture setup
            var fixture = new Fixture();
            var mc = fixture.Build<MyClassA>()
                            .With(x => x.Items, fixture.CreateMany<MyClassB>().ToArray())
                            .Create();
            // Exercise system
            var result = mc.Echo("test");
            // Verify outcome
            result.Should().Be("test");
            // Fixture teardown
        }

        [Fact]
        public void ImperativeStyleWithCustomize()
        {
            // Fixture setup
            var fixture = new Fixture();

            fixture.Customize<MyClassA>(ob =>
                                        ob.With(x => x.Items,
                                                fixture.CreateMany<MyClassB>().ToArray()));

            var mc = fixture.Create<MyClassA>();

            // Exercise system
            var result = mc.Echo("test");
            // Verify outcome
            result.Should().Be("test");
            // Fixture teardown
        }

    }
}