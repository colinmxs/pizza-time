namespace PizzaTime.Core.v2.PointOfSaleMachine.Requests
{
    public class LookupCustomerRequest
    {
        public LookupProperty LookupProperty {get;set;}
        public string SearchValue { get; set; }
    }

    public enum LookupProperty
    {
        Name,
        Phone,
        Address,
        City,
        Remarks
    }
}