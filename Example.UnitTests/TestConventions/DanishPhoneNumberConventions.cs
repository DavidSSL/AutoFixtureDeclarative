using Examples;
using Ploeh.AutoFixture;

namespace Example.UnitTests.TestConventions
{
    public class DanishPhoneNumberConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<DanishPhoneNumber>(c => c.FromFactory((int i) => new DanishPhoneNumber(i + DanishPhoneNumber.MinValue)));
        }
    }
}