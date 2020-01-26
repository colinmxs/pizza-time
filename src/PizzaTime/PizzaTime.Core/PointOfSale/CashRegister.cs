namespace PizzaTime.Core.PointOfSale
{
    public class CashRegister : ICashRegister
    {
        public bool IsOpen => _cashDrawer == null;

        private ICashDrawer _cashDrawer;

        public CashRegister(ICashDrawer cashDrawer)
        {
            _cashDrawer = cashDrawer;
        }

        public ICashDrawer EjectCashDrawer()
        {
            var cashDrawer = _cashDrawer;
            _cashDrawer = null;
            return cashDrawer;
        }

        public void InsertCashDrawer(ICashDrawer cashDrawer)
        {
            _cashDrawer = cashDrawer;
        }
    }
}
