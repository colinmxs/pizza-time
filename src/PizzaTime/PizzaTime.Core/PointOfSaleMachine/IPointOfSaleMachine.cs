namespace PizzaTime.Core.PointOfSaleMachine
{
    using PizzaTime.Core.PointOfSaleMachine.Requests;
    using PizzaTime.Core.PointOfSaleMachine.Responses;

    public interface IPointOfSaleMachine
    {
        SignInResponse SignIn(SignInRequest signInRequest);
        LookupCustomerResponse LookupCustomer(LookupCustomerRequest lookupCustomerRequest);
        AddOrUpdateCustomerResponse AddOrUpdateCustomer(AddOrUpdateCustomerRequest addCustomerRequest);
        PlaceOrderResponse PlaceOrder(PlaceOrderRequest placeOrderRequest);
        EjectCashDrawerResponse EjectCashDrawer(EjectCashDrawerRequest ejectCashRegisterRequest);
    }
}
