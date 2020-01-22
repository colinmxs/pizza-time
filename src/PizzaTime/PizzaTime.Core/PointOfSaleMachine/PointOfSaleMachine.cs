namespace PizzaTime.Core.PointOfSaleMachine
{
    using PizzaTime.Core.PointOfSaleMachine.CashRegister;
    using PizzaTime.Core.PointOfSaleMachine.CustomerRepository;
    using PizzaTime.Core.PointOfSaleMachine.OrderRepository;
    using PizzaTime.Core.PointOfSaleMachine.Printer;
    using PizzaTime.Core.PointOfSaleMachine.Requests;
    using PizzaTime.Core.PointOfSaleMachine.Responses;

    public class PointOfSaleMachine : IPointOfSaleMachine
    {
        private const string _passcode = "admin";
        private bool _signedIn = false;

        private readonly ICashRegister _cashRegister;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPrinter _printer;

        protected PointOfSaleMachine(ICashRegister cashRegister, ICustomerRepository customerRepository, IOrderRepository orderRepository, IPrinter printer)
        {
            _cashRegister = cashRegister;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _printer = printer;
        }

        public AddOrUpdateCustomerResponse AddOrUpdateCustomer(AddOrUpdateCustomerRequest addCustomerRequest)
        {
            Customer customer = _customerRepository.GetByPhoneNumber(addCustomerRequest.LookupPhoneNumber);
            if(customer == null)
            {
                _customerRepository.Add(addCustomerRequest.Customer);
            }

            return new AddOrUpdateCustomerResponse(true)
            {
                Customer = customer
            };
        }

        public EjectCashDrawerResponse EjectCashDrawer(EjectCashDrawerRequest ejectCashRegisterRequest)
        {
            CashDrawer cashDrawer = _cashRegister.EjectCashDrawer();
            return new EjectCashDrawerResponse(true)
            {
                CashDrawer = cashDrawer
            };
        }

        public LookupCustomerResponse LookupCustomer(LookupCustomerRequest lookupCustomerRequest)
        {
            Customer customer = _customerRepository.GetByPhoneNumber(lookupCustomerRequest.PhoneNumber);
            return new LookupCustomerResponse(true)
            {
                Customer = customer
            };
        }

        public PlaceOrderResponse PlaceOrder(PlaceOrderRequest placeOrderRequest)
        {
            Order order = placeOrderRequest.Order;
            bool result = _orderRepository.Add(order);
            Ticket ticket = _printer.PrintTicket(placeOrderRequest.,placeOrderRequest.Order);
            return new PlaceOrderResponse(result)
            {
                Order = order,
                Ticket = ticket
            };
        }

        public SignInResponse SignIn(SignInRequest signInRequest)
        {
            _signedIn = signInRequest.Passcode == _passcode;
            return new SignInResponse(_signedIn);
        }
    }
}
