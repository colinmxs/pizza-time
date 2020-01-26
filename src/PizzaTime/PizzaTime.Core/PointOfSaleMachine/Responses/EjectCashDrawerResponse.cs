using PizzaTime.Core.PointOfSaleMachine.CashRegister.CashDrawer;

namespace PizzaTime.Core.PointOfSaleMachine.Responses
{
    public class EjectCashDrawerResponse
    {
        public EjectCashDrawerResponse(bool success)
        {
            Success = success;
        }

        public ICashDrawer CashDrawer { get; internal set; }
        public bool Success { get; }
    }
}