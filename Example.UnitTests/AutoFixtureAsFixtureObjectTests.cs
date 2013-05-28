using System;
using System.Linq;
using Example.UnitTests.TestConventions;
using Examples;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;
using Xunit.Extensions;

namespace Example.UnitTests
{
    public class AutoFixtureAsFixtureObjectTests
    {
        [Fact]
        public void WithoutAutoFixture()
        {
            // Fixture setup
            var thing1 = new Thing
                {
                    Number = 3
                    ,
                    Text = "Anonymous text 1"
                };
            var thing2 = new Thing
                            {
                                Number = 6
                                ,
                                Text = "Anonymous text 2"
                            };
            var thing3 = new Thing
                            {
                                Number = 1
                                ,
                                Text = "Anonymous text 3"
                            };

            var expectedSum = new[] { thing1, thing2, thing3 }
                .Select(t => t.Number).Sum();

            IMyInterface fake = new FakeMyInterface();

            fake.AddThing(thing1);
            fake.AddThing(thing2);
            fake.AddThing(thing3);

            var sut = new MyClass(fake);

            // Exercise system
            var result = sut.CalculateSumOfThings();
            // Verify outcome
            result.Should().Be(expectedSum);
            // Fixture teardown
        }

        [Fact]
        public void ImperativeStyle()
        {
            // Fixture setup
            var fixture = new Fixture();
            var things = fixture.CreateMany<Thing>().ToList();

            IMyInterface fake = new FakeMyInterface();
            fixture.Register<IMyInterface>(() => fake);

            things.ForEach(t => fake.AddThing(t));

            int expectedSum = things.Select(t => t.Number).Sum();

            var sut = fixture.Create<MyClass>();

            // Exercise system
            var result = sut.CalculateSumOfThings();
            // Verify outcome
            result.Should().Be(expectedSum);
            // Fixture teardown
        }

        [Fact]
        public void ImperativeStyleWithDerivedFixture()
        {
            // Fixture setup
            var fixture = new MyClassFixture();
            var expectedSum = fixture.Things.Select(t => t.Number).Sum();
            var sut = fixture.Create<MyClass>();
            // Exercise system
            var result = sut.CalculateSumOfThings();

            // Verify outcome
            result.Should().Be(expectedSum);
            // Fixture teardown
        }

        [Theory, MyFixtureObjectConventions]
        public void DeclarativeStyle(
            MyClass sut)
        {
            var expectedSum = MyFixtureObjectConventions
                .Things
                .Select(t => t.Number)
                .Sum();

            // Exercise system
            var result = sut.CalculateSumOfThings();

            // Verify outcome
            result.Should().NotBe(0);
            result.Should().Be(expectedSum);
        }
    }
}