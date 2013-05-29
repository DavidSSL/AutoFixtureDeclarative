using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

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

        [Theory, CreatingGenericPopulatedListsTestConventions]
        public void DeclarativeStyle(
            List<int> sut)
        {
            sut.Count.Should().BeGreaterThan(0);
        }
    }

    internal class CreatingGenericPopulatedListsTestConventionsAttribute : AutoDataAttribute
    {
        public CreatingGenericPopulatedListsTestConventionsAttribute():base(new Fixture().Customize(new GenericPopulatedListsTestConventions()))
        {
            
        }
    }

    internal class GenericPopulatedListsTestConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize(new MultipleCustomization());
        }
    }
}