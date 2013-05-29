using System.Collections.Generic;
using System.Linq;

namespace Examples
{
    public class MyClassWithList
    {
        private readonly List<int> _myIntList;

        public MyClassWithList(IEnumerable<int> myIntList)
        {
            _myIntList = myIntList.ToList();
        }

        public List<int> MyIntList
        {
            get { return _myIntList; }
        }
    }
}