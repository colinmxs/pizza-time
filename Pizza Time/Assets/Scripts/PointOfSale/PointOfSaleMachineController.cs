using PizzaTime.Core.CashRegisters;
using PizzaTime.Core.Orders;
using PizzaTime.Core.PaymentOptions;
using PizzaTime.Core.PointOfSale;
using PizzaTime.Core.PointOfSaleMachinev2;
using PizzaTime.Core.Printers;
using System.Collections.Generic;

public class PointOfSaleMachineController : Singleton<PointOfSaleMachineController>
{
    public PointOfSaleMachine POS { get; private set; }
    = Build();

    private static PointOfSaleMachine Build()
    {
        var cashRegister = new CashRegister(new CashDrawer(new List<DollarBill>
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
        //return new PointOfSaleMachine("admin", cashRegister, Seeder.CustomerRepository, new OrderRepository(new List<Order>()), new Printer());
        return new PointOfSaleMachine(Seeder.CustomerRepository, new Dictionary<string, string>());
    }
}