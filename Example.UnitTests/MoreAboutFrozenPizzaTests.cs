using Example.UnitTests.TestConventions;
using Examples;
using FakeItEasy;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoFakeItEasy;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using Xunit.Extensions;

namespace Example.UnitTests
{
    // Based upon http://blog.ploeh.dk/2010/03/26/Moreaboutfrozenpizza/
    public class MoreAboutFrozenPizzaTests
    {
        [Fact]
        public void AddWillPipeMapCorrectly_ImperativeStyle()
        {
            // Fixture setup
            var fixture = new Fixture();

            var basket = fixture.Freeze<Basket>();

            var mapMock = A.Fake<IPizzaMap>();
            fixture.Register(() => mapMock);

            var pizza = fixture.Create<PizzaPresenter>();

            var sut = fixture.Create<BasketPresenter>();

            // Exercise system
            sut.Add(pizza);
            // Verify outcome
            A.CallTo(() => mapMock.Pipe(pizza, basket.Add)).MustHaveHappened(Repeated.Exactly.Once);
            // Fixture teardown
        }

        // Based upon http://nikosbaxevanis.com/2011/12/14/auto-mocking-with-fakeiteasy-and-autofixture/
        [Fact]
        public void AddWillPipeMapCorrectly_ImperativeStyle_Baxevanis()
        {
            // Fixture setup
            var fixture = new Fixture()
                .Customize(new AutoFakeItEasyCustomization());

            var basket = fixture.Freeze<Basket>();
            var mapMock = fixture.Freeze<Fake<IPizzaMap>>();

            var pizza = fixture.Create<PizzaPresenter>();

            var sut = fixture.Create<BasketPresenter>();

            // Exercise system
            sut.Add(pizza);
            // Verify outcome
            A.CallTo(() => mapMock.FakedObject.Pipe(pizza, basket.Add)).MustHaveHappened(Repeated.Exactly.Once);

            // Fixture teardown
        }

        [Theory, AutoFakeData]
        public void AddWillPipeMapCorrectly_DeclarativeStyle(
            [Frozen] Basket basket
            , [Frozen] Fake<IPizzaMap> mapMock 
            , PizzaPresenter pizza
            , BasketPresenter sut
            )
        {
            // Exercise system
            sut.Add(pizza);
            // Verify outcome
            A.CallTo(() => mapMock.FakedObject.Pipe(pizza, basket.Add))
                .MustHaveHappened(Repeated.Exactly.Once);
        }
    }
}