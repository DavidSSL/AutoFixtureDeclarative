namespace Examples
{
    public class DealingWithTypesWithoutPublicCtrs
    {
        private readonly IMyInterface _mi;

        public DealingWithTypesWithoutPublicCtrs(IMyInterface mi)
        {
            _mi = mi;
        }

        public string Echo(string echoStr)
        {
            return echoStr;
        }
    }
}