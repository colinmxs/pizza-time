namespace PizzaTime.Core.PointOfSaleMachine.CashRegister
{
    using PizzaTime.Core.PointOfSaleMachine.CashRegister.CashDrawer;

    public interface ICashRegister
    {
        bool IsOpen { get; set; }

        ICashDrawer EjectCashDrawer();
        void InsertCashDrawer(ICashDrawer cashDrawer);
    }
}
