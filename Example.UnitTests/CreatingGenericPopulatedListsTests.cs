using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace Example.UnitTests
{
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
    }
}