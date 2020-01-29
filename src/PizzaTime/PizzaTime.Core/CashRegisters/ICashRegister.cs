namespace PizzaTime.Core.CashRegisters
{
    public interface ICashRegister
    {
        bool IsOpen { get; }

        ICashDrawer EjectCashDrawer();
        void InsertCashDrawer(ICashDrawer cashDrawer);
    }
}
