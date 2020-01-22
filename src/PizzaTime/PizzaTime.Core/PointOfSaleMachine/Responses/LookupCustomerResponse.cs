namespace PizzaTime.Core.PointOfSaleMachine.Responses
{
    public class LookupCustomerResponse
    {
        private bool v;

        public LookupCustomerResponse(bool v)
        {
            this.v = v;
        }

        internal Customer Customer { get; set; }
    }
}