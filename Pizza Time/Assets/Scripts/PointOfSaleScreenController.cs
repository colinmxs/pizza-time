using System.Collections.Generic;
using UnityEngine;
using PizzaTime.Core.PointOfSale;
using PizzaTime.Core.CashRegisters;
using PizzaTime.Core.PointOfSale.Interfaces;
using PizzaTime.Core.Customers;
using PizzaTime.Core.Orders;
using PizzaTime.Core.Printers;
using PizzaTime.Core.PaymentOptions;
using PizzaTime.Core.PointOfSale.Requests;
using UnityEngine.Events;
using Screen = PizzaTime.Core.PointOfSale.Screen;
using System.Linq;
using PizzaTime.Core.Food.Pizzas.Core;

public partial class PointOfSaleScreenController : MonoBehaviour
{
    public IPointOfSaleMachine pos;
    public UnityEvent OnKeyboardClack;
    IEnumerable<IPointOfSaleView> views;
    OrderRepository orderRepo;
    private void Awake()
    {
        var cashRegi = new CashRegister(new CashDrawer(new List<DollarBill> 
        {
            DollarBill.Twenty,
            DollarBill.Twenty,
            DollarBill.Twenty,
            DollarBill.Twenty,
            DollarBill.Ten,
            DollarBill.Ten,
            DollarBill.Ten,
            DollarBill.Ten,
            DollarBill.Ten,
            DollarBill.Five,
            DollarBill.Five,
            DollarBill.Five,
            DollarBill.Five,
            DollarBill.Five,
            DollarBill.Five,
            DollarBill.Five,
            DollarBill.Five,
            DollarBill.One,
            DollarBill.One,
            DollarBill.One,
            DollarBill.One,
            DollarBill.One,
            DollarBill.One,
            DollarBill.One,
            DollarBill.One
        }));
        views = GetComponentsInChildren<IPointOfSaleView>();
        var seedOrders = new SeedOrders() 
        {
            AmountToSeed = 100
        };
        var orders = seedOrders.Seed().Result;
        orderRepo = new OrderRepository(orders);
        
        var seedCustomers = new SeedCustomers()
        {
            AmountToSeed = 100
        };
        var custies = seedCustomers.Seed().Result;
        pos = new PointOfSaleMachine(cashRegi, new CustomerRepository(custies), orderRepo, new Printer());
        
        if (views != null)
        {
            TryActivateScreen(Screen.SignIn);
        }
    }

    private void TryActivateScreen(Screen screenToActivate)
    {
        if (views != null)
        {
            foreach (var view in views) view.Active = false;

            var screen = views.SingleOrDefault(v => v.Screen == screenToActivate);
            if (screen != null) screen.Active = true;
        }
    }

    public void KeyboardClack()
    {
        OnKeyboardClack.Invoke();
    }

    public void SelectMenuOption(string option)
    {
        var screen = views.SingleOrDefault(v => v.Screen.ToString() == option);
        if (screen != null) TryActivateScreen(screen.Screen);
    }

    public void SignOut()
    {
        pos.SignOut();
        TryActivateScreen(Screen.SignIn);
    }

    public IEnumerable<Order> GetOrders(int page)
    {
        var getOrdersRequest = new GetOrdersRequest
        {
            Page = 0
        };
        var result = pos.GetOrders(getOrdersRequest);
        var orders = result.Orders.ToList();
        return orders;
    }

    public void SignIn(string password)
    {
        var request = new SignInRequest
        {
            Passcode = password
        };
        var result = pos.SignIn(request);
        if (result.Success) TryActivateScreen(Screen.Menu);
    }
}