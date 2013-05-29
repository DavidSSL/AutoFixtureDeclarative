using System.Collections.Generic;
using System.Linq;
using Example.UnitTests.TestConventions;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;
using Xunit.Extensions;

namespace Example.UnitTests
{
    // Based upon http://blog.ploeh.dk/2011/02/08/CreatinggeneralpopulatedlistswithAutoFixture
    public class CreatingGenericPopulatedListsTests
    {
        [Fact]
        public void ImperativeStyle()
        {
            // Fixture setup
            var fixture = new Fixture()
                .Customize(new MultipleCustomization());
            var integers = fixture.Create<IEnumerable<int>>();
            var list = fixture.Create<List<int>>();
            // Exercise system

            // Verify outcome
            integers.ToArray().Count().Should().BeGreaterThan(0);
            list.Count.Should().BeGreaterThan(0);
            // Fixture teardown
        } 

        [Theory, GenericPopulatedListsTestConventions]
        public void DeclarativeStyle(
            List<int> sut)
        {
            sut.Count.Should().BeGreaterThan(0);
        }
    }
}