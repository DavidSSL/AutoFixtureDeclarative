using System.Collections.Generic;

namespace Examples
{
    public interface IMyInterface
    {
        void AddThing(Thing thing);
        IEnumerable<Thing> ListOfThings { get; }
    }
}