using System.Collections.Generic;
using System.Linq;
using Examples;
using Ploeh.AutoFixture;

namespace Example.UnitTests
{
    internal class MyClassFixture : Fixture
    {
        internal MyClassFixture()
        {
            Things = new List<Thing>();

            this.Register<IMyInterface>(() =>
                {
                    var fake = new FakeMyInterface();
                    Things
                        .ToList()
                        .ForEach(fake.AddThing);
                    return fake;
                });

            this.AddManyTo(Things);
        }

        internal List<Thing> Things { get; private set; }
    }
}