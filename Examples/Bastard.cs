namespace Examples
{
    public class Bastard
    {
        private readonly IFoo _foo;

        public Bastard()
            : this(new DefaultFoo())
        {
        }

        public Bastard(IFoo foo)
        {
            LiteGuard.Guard.AgainstNullArgument("foo", foo);
            _foo = foo;
        }

        public IFoo Foo
        {
            get { return _foo; }
        }
    }
}