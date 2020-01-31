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

public class PointOfSaleScreenController : MonoBehaviour
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
        orderRepo = new OrderRepository();
        pos = new PointOfSaleMachine(cashRegi, new CustomerRepository(), orderRepo, new Printer());
        
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
        var list = new List<Order>
        {
            new Order(Order.OrderType.DineIn)
                {
                    Customer = new Customer("Colin", "Smith", "1234567890")
                    {
                        Address = "20 Hidden Hollow Ln",
                        ZipCode = "83338"
                    },
                    OrderItems = new List<IOrderItem>
                    {
                        new PizzaOrderItem(new Pizza(new List<PizzaIngredient>
                        {
                            new PizzaIngredient
                            {
                                CostPerServing = 1.5M,
                                Name = "Pepperoni"
                            }
                        }))
                    }                    
                },
            new Order(Order.OrderType.DineIn)
                {
                    Customer = new Customer("David", "Miller", "0987654321")
                    {
                        Address = "3948 Boston Ln",
                        ZipCode = "39927"
                    },
                    OrderItems = new List<IOrderItem>
                    {
                        new PizzaOrderItem(new Pizza(new List<PizzaIngredient>
                        {
                            new PizzaIngredient
                            {
                                CostPerServing = 1.5M,
                                Name = "Pepperoni"
                            }
                        }))
                    }
                },
            new Order(Order.OrderType.DineIn)
                {
                    Customer = new Customer("Phil", "Merrell", "9077767893")
                    {
                        Address = "20 Boise Street",
                        ZipCode = "83704"
                    },
                    OrderItems = new List<IOrderItem>
                    {
                        new PizzaOrderItem(new Pizza(new List<PizzaIngredient>
                        {
                            new PizzaIngredient
                            {
                                CostPerServing = 1.5M,
                                Name = "Pepperoni"
                            }
                        }))
                    }
                },
            new Order(Order.OrderType.DineIn)
                {
                    Customer = new Customer("Eric", "Salvia", "4499329183")
                    {
                        Address = "27373 lOS ANGEHLSE",
                        ZipCode = "WHAT"
                    },
                    OrderItems = new List<IOrderItem>
                    {
                        new PizzaOrderItem(new Pizza(new List<PizzaIngredient>
                        {
                            new PizzaIngredient
                            {
                                CostPerServing = 1.5M,
                                Name = "Pepperoni"
                            }
                        }))
                    }
                }
        };

        foreach (var item in list)
        {
            var result = pos.PlaceOrder(new PlaceOrderRequest
            {
                Order = item
            });
        }
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