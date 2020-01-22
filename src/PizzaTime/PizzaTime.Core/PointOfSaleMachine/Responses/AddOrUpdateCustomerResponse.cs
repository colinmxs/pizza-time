namespace PizzaTime.Core.PointOfSaleMachine.Responses
{
    public class AddOrUpdateCustomerResponse
    {
        private bool v;

        public AddOrUpdateCustomerResponse(bool v)
        {
            this.v = v;
        }

        internal Customer Customer { get; set; }
    }
}