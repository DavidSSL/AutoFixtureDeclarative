using System.Linq;

namespace Examples
{
    public class MyClass
    {
        private readonly IMyInterface _something;

        public MyClass(IMyInterface something)
        {
            _something = something;
        }

        public int CalculateSumOfThings()
        {
            return _something
                .ListOfThings
                .Select(t => t.Number).Sum();
        }
    }
}