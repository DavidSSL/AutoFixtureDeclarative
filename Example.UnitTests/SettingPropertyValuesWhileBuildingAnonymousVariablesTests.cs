using Example.UnitTests.TestConventions;
using Examples;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;
using Xunit.Extensions;

namespace Example.UnitTests
{
    // Based upon http://blog.ploeh.dk/2009/06/01/SettingPropertyValuesWhileBuildingAnonymousVariablesWithAutoFixture
    public class SettingPropertyValuesWhileBuildingAnonymousVariablesTests
    {
        [Fact]
        public void ImperativeStyle()
        {
            // Fixture setup
            var fixture = new Fixture();
            var min = fixture.Create<int>();
            var max = min + 1;

            var sut = fixture.Build<Filter>()
                             .With(s => s.Max, max)
                             .With(s => s.Min, min)
                             .Create();

            // Exercise system

            // Verify outcome
            sut.Max.Should().BeGreaterThan(sut.Min);
            // Fixture teardown
        }

        [Theory, SetPropertyUsingBuildConventions]
        public void DeclarativeStyle(
             Filter sut
            )
        {
            sut.Max.Should().BeGreaterThan(sut.Min);
        }
    }
}