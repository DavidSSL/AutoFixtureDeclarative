using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

namespace Example.UnitTests.TestConventions
{
    public class MyFixtureObjectConventionsAttribute : AutoDataAttribute
    {
        public MyFixtureObjectConventionsAttribute()
            : base(
                new Fixture().Customize(new MyFixtureObjectConventions()))
        {

        }
    }
}