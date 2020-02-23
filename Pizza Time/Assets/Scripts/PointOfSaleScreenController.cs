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
using System.Threading.Tasks;
using CodenameGenerator.Lite;
using System;

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
        var seed = new SeedCustomers()
        {
            AmountToSeed = 100
        };
        var custies = seed.Seed().Result;
        
        
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

    public class SeedCustomers
    {
        public int AmountToSeed { get; set; }
        private readonly System.Random _random;
        private readonly Generator _generator;
        private readonly Func<System.Random, string> GenerateZipCode = r => r.Next(10000, 99999).ToString();
        private readonly Func<System.Random, string> GenerateAreaCode = r => r.Next(0, 999).ToString().PadRight(3, '0');
        private readonly Func<Generator, string> GenerateMaleFirstName = g => { g.SetParts(WordBank.MaleFirstNames); return g.GenerateAsync().Result; };
        private readonly Func<Generator, string> GenerateFemaleFirstName = g => { g.SetParts(WordBank.FirstNames); return g.GenerateAsync().Result; };
        private readonly Func<Generator, string> GenerateLastName = g => { g.SetParts(WordBank.LastNames); return g.GenerateAsync().Result; };
        private readonly Func<Generator, string> GenerateStreetName = g => { g.SetParts(WordBank.Nouns, RoadSuffixes); return g.GenerateAsync().Result; };

        private static readonly WordBank RoadSuffixes = new ArrayBackedWordBank(new string[] { "Road", "Street", "Plaza", "Way", "Avenue", "Drive", "Lane", "Grove", "Gardens", "Place" });


        public SeedCustomers()
        {
            _generator = new Generator(" ", Casing.PascalCase);
            _random = new System.Random();
        }

        public async Task<IEnumerable<Customer>> Seed()
        {
            var customers = new List<Customer>();

            for (int i = 0; i < AmountToSeed; i++)
            {
                customers.Add(SeedFemaleCustomer());
                customers.Add(SeedMaleCustomer());
            }
            return customers;
        }

        private Customer SeedFemaleCustomer()
        {
            var areaCode = GenerateAreaCode(_random);
            var firstName = GenerateFemaleFirstName(_generator);
            var lastName = GenerateLastName(_generator);
            return new Customer(firstName, lastName, $"{GenerateAreaCode(_random)}-{_random.Next(0, 9999999).ToString().PadRight(7, '0')}")
            {
                Address = $"{GenerateAreaCode(_random)} {GenerateStreetName(_generator)}",
                ZipCode = GenerateZipCode(_random)
            };
        }

        private Customer SeedMaleCustomer()
        {
            var areaCode = GenerateAreaCode(_random);
            var firstName = GenerateMaleFirstName(_generator);
            var lastName = GenerateLastName(_generator);
            return new Customer(firstName, lastName, $"{GenerateAreaCode(_random)}-{_random.Next(0, 9999999).ToString().PadRight(7, '0')}")
            {
                Address = $"{GenerateAreaCode(_random)} {GenerateStreetName(_generator)}",
                ZipCode = GenerateZipCode(_random)
            };
        }
    }
}