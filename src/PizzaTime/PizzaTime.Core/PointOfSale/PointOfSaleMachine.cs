using PizzaTime.Core.PointOfSale.Requests;
using PizzaTime.Core.PointOfSale.Responses;
using System;
using System.Diagnostics.Contracts;

namespace PizzaTime.Core.PointOfSale
{
    public class PointOfSaleMachine : IPointOfSaleMachine
    {
        public enum Screen
        {
            SignIn = 0,
            Menu = 1,
            AddOrder = 2,
            Orders = 3,
            AddCustomer = 4,
            Customers = 5
        }
        private const string _passcode = "admin";
        private bool _signedIn = false;

        private readonly ICashRegister _cashRegister;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IPrinter _printer;

        public Screen LastScreen { get; private set; }
        private Screen _currentScreen;
        public Screen CurrentScreen 
        { 
            get 
            { 
                return _currentScreen; 
            } 
            private set 
            {
                LastScreen = _currentScreen;
                _currentScreen = value;
            }
        }

        public PointOfSaleMachine(ICashRegister cashRegister, ICustomerRepository customerRepository, IOrderRepository orderRepository, IPrinter printer)
        {
            _cashRegister = cashRegister;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _printer = printer;
            CurrentScreen = Screen.SignIn;
        }

        public AddOrUpdateCustomerResponse AddOrUpdateCustomer(AddOrUpdateCustomerRequest addCustomerRequest)
        {
            bool success = false;

            if (!string.IsNullOrEmpty(addCustomerRequest.Customer.PhoneNumber)
                && !string.IsNullOrEmpty(addCustomerRequest.Customer.FirstName)
                && !string.IsNullOrEmpty(addCustomerRequest.Customer.LastName))
            {
                var customer = _customerRepository.GetById(addCustomerRequest.Customer.Id);
                if (customer != null)
                {
                    _customerRepository.Remove(customer);
                }

                _customerRepository.Add(addCustomerRequest.Customer);

                success = true;
            }

            return new AddOrUpdateCustomerResponse(success)
            {
                Customer = addCustomerRequest.Customer
            };
        }

        public EjectCashDrawerResponse EjectCashDrawer(EjectCashDrawerRequest ejectCashRegisterRequest)
        {

            if (ejectCashRegisterRequest.Passcode == _passcode)
            {
                ICashDrawer cashDrawer = _cashRegister.EjectCashDrawer();
                return new EjectCashDrawerResponse(true)
                {
                    CashDrawer = cashDrawer
                };
            }
            else
            {
                return new EjectCashDrawerResponse(false);
            }
        }

        public LookupCustomerResponse LookupCustomer(LookupCustomerRequest lookupCustomerRequest)
        {
            var customer = _customerRepository.GetByPhoneNumber(lookupCustomerRequest.PhoneNumber);
            return new LookupCustomerResponse(true)
            {
                Customer = customer
            };
        }

        public PlaceOrderResponse PlaceOrder(PlaceOrderRequest placeOrderRequest)
        {
            if (placeOrderRequest == null) throw new ArgumentNullException(nameof(placeOrderRequest));

            bool result;

            if ((placeOrderRequest.Order.Type != Order.OrderType.DineIn && placeOrderRequest.Order.Customer == null)
                || placeOrderRequest.Order.OrderItems == null)
            {
                result = false;
            }
            else
            {
                result = _orderRepository.Add(placeOrderRequest.Order);
            }

            var response = new PlaceOrderResponse(result)
            {
                Order = placeOrderRequest.Order
            };
            if (result)
            {
                response.CashDrawer = _cashRegister.EjectCashDrawer();
                response.Tickets = _printer.PrintTickets(placeOrderRequest.Order);
                CurrentScreen = Screen.Orders;
            }            

            return response;
        }

        public SignInResponse SignIn(SignInRequest signInRequest)
        {
            if (signInRequest == null) throw new ArgumentNullException(nameof(signInRequest));
            _signedIn = signInRequest.Passcode == _passcode;
            if (_signedIn) CurrentScreen = Screen.Menu;
            return new SignInResponse(_signedIn);
        }
    }
}
