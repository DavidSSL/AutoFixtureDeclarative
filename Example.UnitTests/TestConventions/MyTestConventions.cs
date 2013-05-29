using Examples;
using Ploeh.AutoFixture;

namespace Example.UnitTests.TestConventions
{
    public class MyTestConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            const string knownText = "This text is not anonymous";

            fixture.Customize<IMyInterface>(
                c => c.FromFactory((int i) => new FakeMyInterface(i, knownText)));
        }
    }
}