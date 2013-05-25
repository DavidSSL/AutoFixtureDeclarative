using System.Collections.Generic;
using System.Linq;
using Examples;
using Ploeh.AutoFixture;

namespace Example.UnitTests
{
    public class MyFixtureObjectConventions : ICustomization
    {
        public static List<Thing> Things { get; private set; }

        public void Customize(IFixture fixture)
        {
            Things = new List<Thing>();

            fixture.Register<IMyInterface>(() =>
                {
                    var fake = new FakeMyInterface();
                    Things
                        .ToList()
                        .ForEach(fake.AddThing);
                    return fake;
                });

            fixture.AddManyTo(Things);
        }
    }
}