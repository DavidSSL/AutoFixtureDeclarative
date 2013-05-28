using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoFakeItEasy;
using Ploeh.AutoFixture.Xunit;

namespace Example.UnitTests.TestConventions
{
    internal class AutoFakeDataAttribute : AutoDataAttribute
    {
        public AutoFakeDataAttribute()
            : base(new Fixture().Customize(new AutoFakeItEasyCustomization()
                       ))
        {
            
        }
    }
}