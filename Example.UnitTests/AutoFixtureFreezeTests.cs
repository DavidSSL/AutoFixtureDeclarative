using System;
using Examples;
using FluentAssertions;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace Example.UnitTests
{
    // Based upon http://blog.ploeh.dk/2010/03/17/AutoFixtureFreeze/
    public class AutoFixtureFreezeTests
    {
        [Fact]
        public void NameIsCorrectImperative()
        {
            // Fixture setup
            var fixture = new Fixture();

            var expectedName = fixture.Create("Name");
            fixture.Register(() => expectedName);

            var sut = fixture.Create<Pizza>();
            // Exercise system
            var result = sut.Name;
            // Verify outcome
            result.Should().Be(expectedName ,"Names should match");
            // Fixture teardown
        }

        [Fact]
        public void NameIsCorrect_FreezeImperative()
        {
            // Fixture setup
            var fixture = new Fixture();

            var expectedName = fixture.Freeze("Name");
            var sut = fixture.Create<Pizza>();
            // Exercise system
            var result = sut.Name;
            // Verify outcome
            result.Should().Be(expectedName, "Names should match");
            // Fixture teardown
        }

        [Theory, FreezeTestConventions]
        public void NameIsCorrect_FreezeDeclarative(
            [Frozen]string name
            , Pizza sut
            )
        {
            // Exercise system
            var result = sut.Name;
            // Verify outcome
            result.Should().Be(name, "Names should match");
        }
    }

    internal class FreezeTestConventionsAttribute : AutoDataAttribute
    {
        public FreezeTestConventionsAttribute()
            : base(new Fixture().Customize(new FreezeTestConventions()))
        {

        }
    }

    internal class FreezeTestConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Freeze("Name");
        }
    }
}