namespace PizzaTime.Core.PointOfSale
{
    public interface ICashRegister
    {
        bool IsOpen { get; }

        ICashDrawer EjectCashDrawer();
        void InsertCashDrawer(ICashDrawer cashDrawer);
    }
}
