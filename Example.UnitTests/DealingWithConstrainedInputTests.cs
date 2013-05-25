using Examples;
using Ploeh.AutoFixture;
using Xunit;
using Xunit.Extensions;

namespace Example.UnitTests
{
    // Based upon http://blog.ploeh.dk/2009/05/01/DealingWithConstrainedInput/
    public class DealingWithConstrainedInputTests
    {
        [Fact]
        public void ImperativeStyle()
        {
            // Fixture setup
            var fixture = new Fixture();

            fixture.Register<int, DanishPhoneNumber>(i =>
                new DanishPhoneNumber(i + DanishPhoneNumber.MinValue));

            var sut = fixture.Create<Contact>();
            // Exercise system

            // Verify outcome

            // Fixture teardown
        }

        [Theory, DanishPhoneNumberConventions]
        public void DeclarativeStyle(
            Contact sut)
        {
            sut.Echo("Test");
        }
    }
}