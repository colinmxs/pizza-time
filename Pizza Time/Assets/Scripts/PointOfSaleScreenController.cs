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
using PizzaTime.Core.PointOfSale.Responses;
using UnityEngine.Events;

public class PointOfSaleScreenController : MonoBehaviour
{
    public IPointOfSaleMachine pos;
    public UnityEvent OnKeyboardClack;
    IEnumerable<IPointOfSaleView> views;

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
        pos = new PointOfSaleMachine(cashRegi, new CustomerRepository(), new OrderRepository(), new Printer(), views);             
    }

    public void KeyboardClack()
    {
        Debug.Log("On Keyboard Clack");
        OnKeyboardClack.Invoke();
    }

    public void SignOut()
    {
        pos.SignOut();
    }

    public void SignIn(string password)
    {
        var request = new SignInRequest
        {
            Passcode = password
        };
        var result = pos.SignIn(request);
    }
}