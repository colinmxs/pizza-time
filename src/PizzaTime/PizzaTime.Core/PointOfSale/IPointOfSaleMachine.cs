namespace PizzaTime.Core.PointOfSale
{
    using PizzaTime.Core.PointOfSale.Requests;
    using PizzaTime.Core.PointOfSale.Responses;   
    
    public interface IPointOfSaleMachine
    {
        void SignOut();
        SignInResponse SignIn(SignInRequest signInRequest);
        LookupCustomerResponse LookupCustomer(LookupCustomerRequest lookupCustomerRequest);
        AddOrUpdateCustomerResponse AddOrUpdateCustomer(AddOrUpdateCustomerRequest addCustomerRequest);
        PlaceOrderResponse PlaceOrder(PlaceOrderRequest placeOrderRequest);
        EjectCashDrawerResponse EjectCashDrawer(EjectCashDrawerRequest ejectCashRegisterRequest);
    }
}
