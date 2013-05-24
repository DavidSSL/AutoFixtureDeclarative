namespace Examples
{
    public class Contact
    {
        private readonly string _name;
        private readonly DanishPhoneNumber _phoneNumber;

        public Contact(string name, DanishPhoneNumber phoneNumber)
        {
            _name = name;
            _phoneNumber = phoneNumber;
        }
    }
}