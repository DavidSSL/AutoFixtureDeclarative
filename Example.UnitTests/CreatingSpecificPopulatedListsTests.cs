using System.Collections.Generic;
using System.Linq;
using Examples;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace Example.UnitTests
{
    public class CreatingSpecificPopulatedListsTests
    {
        [Fact]
        public void Imperative_InitiallyEmptyList()
        {
            // Fixture setup
            var fixture = new Fixture();
            var list = fixture.Create<List<int>>();
            fixture.AddManyTo(list);
            // Exercise system
            var sut = fixture.Create<MyClassWithList>();
            // Verify outcome
            sut.MyIntList.Count.Should().BeGreaterThan(0, "because the list must be populated");
            // Fixture teardown
        }

        [Fact]
        public void Imperative_PopulatedList()
        {
            // Fixture setup
            var fixture = new Fixture();
            fixture.Register(() => 
                fixture.CreateMany<int>().ToList());
            // Exercise system
            var sut = fixture.Create<MyClassWithList>();
            // Verify outcome
            sut.MyIntList.Count.Should().BeGreaterThan(0, "because the list must be populated");
            // Fixture teardown
        }
    }
}