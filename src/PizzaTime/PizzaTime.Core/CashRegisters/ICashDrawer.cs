namespace PizzaTime.Core.CashRegisters
{
    using PizzaTime.Core.PaymentOptions;
    using PizzaTime.Core.Tickets;
    using System.Collections.Generic;

    public interface ICashDrawer
    {
        int Fives { get; }
        int Twenties { get; }
        int Checks { get; }
        int CreditCardStubs { get; }
        int Hundreds { get; }
        int Ones { get; }
        int Tens { get; }
        int Fifties { get; }

        void AddCreditCardStub(CreditCardStub stub);
        void AddDollarBills(IEnumerable<DollarBill> bills);
        void AddCheck(Check check);
        IEnumerable<CreditCardStub> RemoveCreditCardStubs();
        IEnumerable<Check> RemoveChecks();
        IEnumerable<DollarBill> RemoveDollarBills();
        DollarBill RemoveDollarBill(DollarBill bill);
    }
}
