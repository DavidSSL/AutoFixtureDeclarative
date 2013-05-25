using Ploeh.AutoFixture;
using Ploeh.AutoFixture.Xunit;

namespace Example.UnitTests
{
    public class DanishPhoneNumberConventionsAttribute : AutoDataAttribute
    {
        public DanishPhoneNumberConventionsAttribute()
            : base(new Fixture().Customize(new DanishPhoneNumberConventions()))
        {}
    }
}