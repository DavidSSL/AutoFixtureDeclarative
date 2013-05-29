using Examples;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;

namespace Example.UnitTests.TestConventions
{
    internal class ConstructorStrategiesForBastardClassOnlyTestConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Bastard>(c => c.FromFactory(
                new MethodInvoker(
                    new GreedyConstructorQuery())));

            fixture.Register<IFoo>(
                fixture.Create<DummyFoo>);
        }
    }
}