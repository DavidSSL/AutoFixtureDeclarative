namespace Examples
{
    public class BasketPresenter
    {
        private readonly Basket _basket;

        private readonly IPizzaMap _map;

        public BasketPresenter(Basket basket, IPizzaMap map)
        {
            LiteGuard.Guard.AgainstNullArgument("basket", basket);
            LiteGuard.Guard.AgainstNullArgument("map", map);
            _basket = basket;

            _map = map;

        }

        public void Add(PizzaPresenter presenter)
        {
            _map.Pipe(presenter, _basket.Add);
        }
    }
}