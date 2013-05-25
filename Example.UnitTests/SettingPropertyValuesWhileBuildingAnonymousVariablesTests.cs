using System;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace Example.UnitTests
{
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
    }

    public class Filter
    {
        private int _min;
        public int Max { get; set; }

        public int Min
        {
            get { return _min; }

            set
            {

                if (value > Max)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _min = value;
            }
        }
    }
}