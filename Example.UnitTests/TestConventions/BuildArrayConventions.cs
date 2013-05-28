using System.Linq;
using Examples;
using Ploeh.AutoFixture;

namespace Example.UnitTests.TestConventions
{
    public class BuildArrayConventions : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<MyClassA>(ob =>
                                        ob.With(x => x.Items,
                                                fixture.CreateMany<MyClassB>().ToArray()));
        }
    }
}