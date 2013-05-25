using System.Collections.Generic;

namespace Examples
{
    public class FakeMyInterface : IMyInterface
    {
        private readonly List<Thing> _listOfThings = new List<Thing>();

        public FakeMyInterface()
        {
            
        }

        public FakeMyInterface(int number, string text)
        {
            
        }

        public IEnumerable<Thing> ListOfThings
        {
            get { return _listOfThings; }
        }

        public void AddThing(Thing thing)
        {
            _listOfThings.Add(thing);
        }
    }
}