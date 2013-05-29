using System.Collections.Generic;
using System.Linq;
using Example.UnitTests.TestConventions;
using Examples;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;
using Xunit.Extensions;

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
            var sut = fixture.Create<MyClassWithList>();
            // Exercise system
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
            var sut = fixture.Create<MyClassWithList>();
            // Exercise system
            // Verify outcome
            sut.MyIntList.Count.Should().BeGreaterThan(0, "because the list must be populated");
            // Fixture teardown
        }

        [Theory, SpecificPopulatedListsTestConventions]
        public void DeclarativeStyle(
            MyClassWithList sut)
        {
            // Verify outcome
            sut.MyIntList.Count.Should().BeGreaterThan(0, "because the list must be populated");
            // Fixture teardown
        }
    }
}