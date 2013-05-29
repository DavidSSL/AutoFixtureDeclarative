using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

namespace Example.UnitTests.TestConventions
{
    internal class ConstructorStrategiesForBastardClassOnlyTestConventionsAttribute : AutoDataAttribute
    {
        public ConstructorStrategiesForBastardClassOnlyTestConventionsAttribute():base(new Fixture().Customize(new ConstructorStrategiesForBastardClassOnlyTestConventions()))
        {
            
        }
    }
}