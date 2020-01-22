namespace PizzaTime.Core.PointOfSaleMachine.Responses
{
    public class EjectCashDrawerResponse
    {
        private bool success;

        public EjectCashDrawerResponse(bool success)
        {
            this.success = success;
        }

        public CashDrawer CashDrawer { get; internal set; }
    }
}