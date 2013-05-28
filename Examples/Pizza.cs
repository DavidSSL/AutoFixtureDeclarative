namespace Examples
{
    public class Pizza
    {
        private readonly string _name;

        public Pizza(string name)
        {
            LiteGuard.Guard.AgainstNullArgument("name", name);
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }
    }
}