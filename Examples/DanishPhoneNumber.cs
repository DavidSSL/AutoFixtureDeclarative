using System;

namespace Examples
{
    public class DanishPhoneNumber
    {
        private int _number;

        public DanishPhoneNumber(int number)
        {

            if ((number < MinValue)
                || (number > 99999999))
            {
                throw new ArgumentOutOfRangeException("number");
            }
            _number = number;
        }

        public static int MinValue
        {
            get { return 112; }
        }
    }
}