using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

namespace Example.UnitTests.TestConventions
{
    public class DanishPhoneNumberConventionsAttribute : AutoDataAttribute
    {
        public DanishPhoneNumberConventionsAttribute()
            : base(new Fixture().Customize(new DanishPhoneNumberConventions()))
        {}
    }
}