using Examples;
using Ploeh.AutoFixture;

namespace Example.UnitTests.TestConventions
{
    public class SetPropertyUsingBuildConvention : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            var min = fixture.Create<int>();
            var max = min + 1;

            var filter = new Filter();

            fixture
                .Build<Filter>()
                .FromFactory(() => 
                             filter)
                .With(s => s.Max, max)
                .With(s => s.Min, min)
                .Create();

            fixture.Register(() => filter);
        }
    }
}