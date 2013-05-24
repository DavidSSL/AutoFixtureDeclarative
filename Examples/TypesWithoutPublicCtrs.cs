namespace Examples
{
    public class TypesWithoutPublicCtrs
    {
        private readonly IMyInterface _mi;

        public TypesWithoutPublicCtrs(IMyInterface mi)
        {
            _mi = mi;
        }
    }
}