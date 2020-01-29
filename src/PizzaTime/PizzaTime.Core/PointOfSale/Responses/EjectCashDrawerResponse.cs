using PizzaTime.Core.CashRegisters;

namespace PizzaTime.Core.PointOfSale.Responses
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