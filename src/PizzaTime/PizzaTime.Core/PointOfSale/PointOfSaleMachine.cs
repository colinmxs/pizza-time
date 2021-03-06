﻿namespace PizzaTime.Core.PointOfSale
{
    //using PizzaTime.Core.CashRegisters;
    //using PizzaTime.Core.Customers;
    //using PizzaTime.Core.Orders;
    //using PizzaTime.Core.PointOfSale.Requests;
    //using PizzaTime.Core.PointOfSale.Responses;
    //using PizzaTime.Core.Printers;
    //using System;
    //using System.Collections.Generic;
    //using System.Linq;

    //public class PointOfSaleMachine : IPointOfSaleMachine
    //{
    //    private bool _signedIn = false;

    //    private readonly Dictionary<string, string> _notes = new Dictionary<string, string>();
    //    private readonly string _passcode;
    //    private readonly ICashRegister _cashRegister;
    //    private readonly ICustomerRepository _customerRepository;
    //    private readonly IOrderRepository _orderRepository;
    //    private readonly IPrinter _printer;

    //    public PointOfSaleMachine(string passCode, ICashRegister cashRegister, ICustomerRepository customerRepository, IOrderRepository orderRepository, IPrinter printer)
    //    {
    //        _passcode = passCode;
    //        _cashRegister = cashRegister;
    //        _customerRepository = customerRepository;
    //        _orderRepository = orderRepository;
    //        _printer = printer;            
    //    }


    //    public EjectCashDrawerResponse EjectCashDrawer(EjectCashDrawerRequest ejectCashRegisterRequest)
    //    {

    //        if (ejectCashRegisterRequest.Passcode == _passcode)
    //        {
    //            ICashDrawer cashDrawer = _cashRegister.EjectCashDrawer();
    //            return new EjectCashDrawerResponse(true)
    //            {
    //                CashDrawer = cashDrawer
    //            };
    //        }
    //        else
    //        {
    //            return new EjectCashDrawerResponse(false);
    //        }
    //    }

    //    private IEnumerable<(Customer, string)> AttachNotes(IEnumerable<Customer> customers)
    //    {
    //        return customers.Select(c =>
    //        {
    //            var valueExists = _notes.TryGetValue(c.Id.ToString(), out string note);
    //            return (c, valueExists ? note : "");
    //        });
    //    }

    //    public LookupCustomerResponse LookupCustomer(LookupCustomerRequest lookupCustomerRequest)
    //    {
    //        IEnumerable<Customer> customers = new List<Customer>();
    //        switch (lookupCustomerRequest.LookupProperty)
    //        {
    //            case LookupProperty.Name:
    //                customers = _customerRepository.Search(c => c.FirstName.ToUpperInvariant().Contains(lookupCustomerRequest.SearchValue.ToUpperInvariant()) || c.LastName.ToUpperInvariant().Contains(lookupCustomerRequest.SearchValue.ToUpperInvariant()));
    //                break;
    //            case LookupProperty.Phone:
    //                customers = _customerRepository.Search(c => c.PhoneNumber.Contains(lookupCustomerRequest.SearchValue));
    //                break;
    //            case LookupProperty.Address:
    //                customers = _customerRepository.Search(c => c.Address.Contains(lookupCustomerRequest.SearchValue));
    //                break;
    //            case LookupProperty.City:
    //                customers = _customerRepository.Search(c => c.ZipCode.Contains(lookupCustomerRequest.SearchValue));
    //                break;
    //            case LookupProperty.Remarks:
    //                var tempCustomers = new List<Customer>();
    //                foreach (var note in _notes)
    //                {
    //                    if (note.Value.Contains(lookupCustomerRequest.SearchValue))
    //                    {
    //                        var key = note.Key;
    //                        tempCustomers.AddRange(_customerRepository.Search(c => c.Id.ToString() == key));
    //                    }
    //                }
    //                customers = tempCustomers;
    //                break;
    //            default:
    //                customers = new List<Customer>(0);
    //                break;
    //        }
            
    //        return new LookupCustomerResponse(true)
    //        {
    //            Customers = AttachNotes(customers)
    //        };
    //    }

    //    public PlaceOrderResponse PlaceOrder(PlaceOrderRequest placeOrderRequest)
    //    {
    //        if (placeOrderRequest == null) throw new ArgumentNullException(nameof(placeOrderRequest));

    //        bool result;

    //        if ((placeOrderRequest.Order.Type != Order.OrderType.DineIn && placeOrderRequest.Order.Customer == null)
    //            || placeOrderRequest.Order.OrderItems == null)
    //        {
    //            result = false;
    //        }
    //        else
    //        {
    //            result = _orderRepository.Add(placeOrderRequest.Order);
    //        }

    //        var response = new PlaceOrderResponse(result)
    //        {
    //            Order = placeOrderRequest.Order
    //        };
    //        if (result)
    //        {
    //            response.CashDrawer = _cashRegister.EjectCashDrawer();
    //            response.Tickets = _printer.PrintTickets(placeOrderRequest.Order);
    //        }            

    //        return response;
    //    }
        
    //    public void SignOut()
    //    {
    //        _signedIn = false;
    //    }

    //    public GetOrdersResponse GetOrders(GetOrdersRequest getOrdersRequest)
    //    {
    //        if (getOrdersRequest == null) throw new ArgumentNullException(nameof(getOrdersRequest));
    //        var orders = _orderRepository.GetOrders(getOrdersRequest.Page);
    //        return new GetOrdersResponse
    //        {
    //            Orders = orders
    //        };
    //    }

    //    public SignInResponse SignIn(SignInRequest signInRequest)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public AddOrUpdateCustomerResponse AddOrUpdateCustomer(AddOrUpdateCustomerRequest addCustomerRequest)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
