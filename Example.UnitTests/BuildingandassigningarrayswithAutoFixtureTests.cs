using System.Linq;
using Example.UnitTests.TestConventions;
using Examples;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;
using Xunit.Extensions;

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
            var sut = fixture.Create<MyClassA>();
            sut.Items = fixture.CreateMany<MyClassB>().ToArray();
            // Exercise system
            var result = sut.Echo("test");
            // Verify outcome
            result.Should().Be("test");
            // Fixture teardown
        }

        [Fact]
        public void ImperativeStyleWithBuild()
        {
            // Fixture setup
            var fixture = new Fixture();
            var sut = fixture.Build<MyClassA>()
                            .With(x => x.Items, fixture.CreateMany<MyClassB>().ToArray())
                            .Create();
            // Exercise system
            var result = sut.Echo("test");
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

            var sut = fixture.Create<MyClassA>();

            // Exercise system
            var result = sut.Echo("test");
            // Verify outcome
            result.Should().Be("test");
            // Fixture teardown
        }

        [Theory, BuildArrayConventions]
        public void DeclarativeStyle(
            MyClassA sut)
        {
            // Exercise system
            var result = sut.Echo("test");
            // Verify outcome
            result.Should().Be("test");
        }
    }
}