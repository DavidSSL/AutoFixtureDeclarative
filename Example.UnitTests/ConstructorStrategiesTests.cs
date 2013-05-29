using Examples;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Kernel;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace Example.UnitTests
{
    // Based upon http://blog.ploeh.dk/2011/04/19/ConstructorstrategiesforAutoFixture/
    public class ConstructorStrategiesTests
    {
        [Fact]
        public void ImperativeStyle_ExampleOfModestConstructorQuery()
        {
            // Fixture setup
            var fixture = new Fixture();
            fixture.Register<IFoo>(
                fixture.Create<DummyFoo>);

            var b = fixture.Create<Bastard>();
            // Exercise system

            // Verify outcome
            // Although we've configured DummyFoo to be injected when creating a Bastard class
            // we are getting a DefaultFoo injected instead since we are not using the 
            // greediest constructor as the following test shows
            Assert.IsAssignableFrom<DefaultFoo>(b.Foo);
            // Fixture teardown
        }

        [Fact]
        public void ImperativeStyle_ExampleofGreedyForBastardClass()
        {
            // Fixture setup
            var fixture = new Fixture();
            fixture.Customize<Bastard>(c => c.FromFactory(
                new MethodInvoker(
                    new GreedyConstructorQuery())));

            fixture.Register<IFoo>(
                fixture.Create<DummyFoo>);
            var b = fixture.Create<Bastard>();

            // Exercise system

            // Verify outcome
            Assert.IsAssignableFrom<DummyFoo>(b.Foo);
            // Fixture teardown
        }

        [Fact]
        public void ImperativeStyle_ExampleOfGreedyForEveryClass()
        {
            // Fixture setup
            var fixture = new Fixture();

            fixture.Customizations.Add(
                new MethodInvoker(
                    new GreedyConstructorQuery()));
            fixture.Register<IFoo>(
                fixture.Create<DummyFoo>);
            var b = fixture.Create<Bastard>();

            // Exercise system

            // Verify outcome
            Assert.IsAssignableFrom<DummyFoo>(b.Foo);

            // Fixture teardown
        }

        [Theory, ConstructorStrategiesForBastardClassOnlyTestConventions]
        public void DeclarativeStyle_ExampleOfGreedyForBastardClass(
            Bastard sut)
        {
            Assert.IsAssignableFrom<DummyFoo>(sut.Foo);
        }

        [Theory, ConstructorStrategiesForAllClassesTestConventions]
        public void DeclarativeStyle_ExampleOfGreedForAllClasses(
            Bastard sut)
        {
            Assert.IsAssignableFrom<DummyFoo>(sut.Foo);
        }
    }

    internal class ConstructorStrategiesForAllClassesTestConventionsAttribute : AutoDataAttribute
    {
        public ConstructorStrategiesForAllClassesTestConventionsAttribute():base(new Fixture().Customize(new ConstructorStrategiesForAllClassesTestConventions()))
        {
            
        }
    }

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

    internal class ConstructorStrategiesForBastardClassOnlyTestConventionsAttribute : AutoDataAttribute
    {
        public ConstructorStrategiesForBastardClassOnlyTestConventionsAttribute():base(new Fixture().Customize(new ConstructorStrategiesForBastardClassOnlyTestConventions()))
        {
            
        }
    }

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