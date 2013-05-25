using System;

namespace Examples
{
    public class Filter
    {
        private int _min;
        public int Max { get; set; }

        public int Min
        {
            get { return _min; }

            set
            {
                if (value > Max)
                {
                    throw new ArgumentOutOfRangeException("value");
                }
                _min = value;
            }
        }
    }
}