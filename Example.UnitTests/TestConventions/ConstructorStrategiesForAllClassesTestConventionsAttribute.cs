using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

namespace Example.UnitTests.TestConventions
{
    internal class ConstructorStrategiesForAllClassesTestConventionsAttribute : AutoDataAttribute
    {
        public ConstructorStrategiesForAllClassesTestConventionsAttribute():base(new Fixture().Customize(new ConstructorStrategiesForAllClassesTestConventions()))
        {
            
        }
    }
}