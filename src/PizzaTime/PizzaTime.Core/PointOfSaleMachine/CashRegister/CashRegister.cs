namespace PizzaTime.Core.PointOfSaleMachine.CashRegister
{
    using PizzaTime.Core.PointOfSaleMachine.CashRegister.CashDrawer;
    public class CashRegister : ICashRegister
    {
        public bool IsOpen { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public ICashDrawer EjectCashDrawer()
        {
            throw new System.NotImplementedException();
        }

        public void InsertCashDrawer(ICashDrawer cashDrawer)
        {
            throw new System.NotImplementedException();
        }
    }
}
