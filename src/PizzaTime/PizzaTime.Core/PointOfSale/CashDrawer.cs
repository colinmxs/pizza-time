namespace PizzaTime.Core.PointOfSale
{
    using System.Collections.Generic;
    using System.Linq;

    public class CashDrawer : ICashDrawer
    {
        private readonly List<DollarBill> _dollarBills;
        private readonly List<Check> _checks;
        private readonly List<CreditCardStub> _creditCardStubs;

        private IEnumerable<DollarBill> HundredDollarBills => _dollarBills.Where(bill => bill.Amount == 100.00M).AsEnumerable();
        private IEnumerable<DollarBill> FiftyDollarBills => _dollarBills.Where(bill => bill.Amount == 50.00M).AsEnumerable();
        private IEnumerable<DollarBill> TwentyDollarBills => _dollarBills.Where(bill => bill.Amount == 20.00M).AsEnumerable();
        private IEnumerable<DollarBill> TenDollarBills => _dollarBills.Where(bill => bill.Amount == 10.00M).AsEnumerable();
        private IEnumerable<DollarBill> FiveDollarBills => _dollarBills.Where(bill => bill.Amount == 5.00M).AsEnumerable();
        private IEnumerable<DollarBill> OneDollarBills => _dollarBills.Where(bill => bill.Amount == 1.00M).AsEnumerable();

        public int Fives => FiveDollarBills.Count();

        public int Twenties => TwentyDollarBills.Count();

        public int Checks => _checks.Count;

        public int CreditCardStubs => _creditCardStubs.Count;

        public int Hundreds => HundredDollarBills.Count();

        public int Ones => OneDollarBills.Count();

        public int Tens => TenDollarBills.Count();

        public int Fifties => FiftyDollarBills.Count();

        public CashDrawer(IEnumerable<DollarBill> dollarBills)
        {
            _dollarBills = dollarBills.ToList();
            _checks = new List<Check>();
            _creditCardStubs = new List<CreditCardStub>();
        }

        public void AddCheck(Check check)
        {
            _checks.Add(check);
        }

        public void AddCreditCardStub(CreditCardStub stub)
        {
            _creditCardStubs.Add(stub);
        }

        public void AddDollarBills(IEnumerable<DollarBill> bills)
        {
            foreach (var bill in bills)
            {
                _dollarBills.Add(bill);
            }
        }

        public IEnumerable<Check> RemoveChecks()
        {
            var checks = new Check[_checks.Count];
            _checks.CopyTo(checks);
            _checks.Clear();
            return checks;
        }

        public IEnumerable<CreditCardStub> RemoveCreditCardStubs()
        {
            CreditCardStub[] stubs = new CreditCardStub[_creditCardStubs.Count];
            _creditCardStubs.CopyTo(stubs);
            _creditCardStubs.Clear();
            return stubs;
        }

        public DollarBill RemoveDollarBill(DollarBill bill)
        {
            var result = _dollarBills.Find(b => b == bill);
            if (result == null) throw new System.Exception("Dollar not found");
            _dollarBills.Remove(bill);
            return bill;
        }

        public IEnumerable<DollarBill> RemoveDollarBills()
        {
            DollarBill[] bills = new DollarBill[_dollarBills.Count];
            _dollarBills.CopyTo(bills);
            _dollarBills.Clear();
            return bills;
        }
    }
}