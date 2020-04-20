﻿using System.Collections.Generic;
using UnityEngine;
using PizzaTime.Core.PointOfSale;
using PizzaTime.Core.CashRegisters;
using PizzaTime.Core.PointOfSale.Interfaces;
using PizzaTime.Core.Orders;
using PizzaTime.Core.Printers;
using PizzaTime.Core.PaymentOptions;
using PizzaTime.Core.PointOfSale.Requests;
using UnityEngine.Events;
using Screen = PizzaTime.Core.PointOfSale.Screen;
using System.Linq;
using PizzaTime.Core.Customers;

public partial class PointOfSaleScreenController : MonoBehaviour
{
    public IPointOfSaleMachine pos;
    public UnityEvent OnKeyboardClack;
    public SeederController Seeder;

    IEnumerable<IPointOfSaleView> views;
    private void Start()
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

        pos = new PointOfSaleMachine("admin", cashRegi, Seeder.CustomerRepository, new OrderRepository(new List<Order>()), new Printer());
        
        if (views != null)
        {
            TryActivateScreen(views.First().Screen);
        }
    }

    public void TryActivateScreen(string screenToActivate)
    {
        if (views != null)
        {
            var screen = views.SingleOrDefault(v => v.Screen.ToString() == screenToActivate);
            if(screen != null) TryActivateScreen(screen.Screen);
        }
    }

    public void TryActivateScreen(Screen screenToActivate)
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

    public void SignOut()
    {
        pos.SignOut();
        TryActivateScreen(Screen.SignIn);
    }
}