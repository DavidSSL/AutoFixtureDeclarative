using Examples;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

namespace Example.UnitTests.TestConventions
{
    internal class ConstructorStrategiesForAllClassesTestConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(
                new MethodInvoker(
                    new GreedyConstructorQuery()));
            fixture.Register<IFoo>(
                fixture.Create<DummyFoo>);
        }
    }
}