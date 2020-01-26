namespace PizzaTime.Core.Tests.PointOfSale
{
    using FakeItEasy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.PointOfSale;
    using Shouldly;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestClass]
    public class CashDrawerTests
    {
        ICashDrawer cashDrawer;

        [TestInitialize]
        public void Initialize()
        {
            List<DollarBill> bills = new List<DollarBill>()
            {
                DollarBill.Twenty,
                DollarBill.Twenty,
                DollarBill.Twenty,
                DollarBill.Five,
                DollarBill.Five,
                DollarBill.Five,
                DollarBill.Five
            };
            
            cashDrawer = new CashDrawer(bills);
        }

        [TestMethod]
        public void CashDrawer_ConstructorAddsBills()
        {
            cashDrawer.Fives.ShouldBe(4);
            cashDrawer.Twenties.ShouldBe(3);
            cashDrawer.Checks.ShouldBe(0);
            cashDrawer.CreditCardStubs.ShouldBe(0);
        }

        [TestMethod]
        public void AddCreditCardStub_IncrementsCreditCardStubCount()
        {
            var count = cashDrawer.CreditCardStubs;
            cashDrawer.AddCreditCardStub(A.Fake<CreditCardStub>());
            cashDrawer.CreditCardStubs.ShouldBe(count + 1);
        }

        [TestMethod]
        public void RemoveCreditCardStubs_ReturnsAllCreditCardStubs()
        {
            var stub = A.Fake<CreditCardStub>();
            cashDrawer.AddCreditCardStub(stub);
            var count = cashDrawer.CreditCardStubs;
            var stubs = cashDrawer.RemoveCreditCardStubs();
            stubs.Count().ShouldBe(count);
            cashDrawer.CreditCardStubs.ShouldBe(0);
        }

        [TestMethod]
        public void AddDollarBills_SortsAndIncrementsBillCounts()
        {
            var hundredsCount = cashDrawer.Hundreds;
            var onesCount = cashDrawer.Ones;
            var tensCount = cashDrawer.Tens;
            var fiftiesCount = cashDrawer.Fifties;

            cashDrawer.AddDollarBills(new List<DollarBill>()
            {
                DollarBill.Hundred,
                DollarBill.One,
                DollarBill.Ten,
                DollarBill.Fifty
            });

            cashDrawer.Hundreds.ShouldBe(hundredsCount + 1);
            cashDrawer.Ones.ShouldBe(onesCount + 1);
            cashDrawer.Tens.ShouldBe(tensCount + 1);
            cashDrawer.Fifties.ShouldBe(fiftiesCount + 1);
        }

        [TestMethod]
        public void AddCheck_IncrementsCheckCount()
        {
            var checkCount = cashDrawer.Checks;
            cashDrawer.AddCheck(A.Fake<Check>());
            cashDrawer.Checks.ShouldBe(checkCount + 1);
        }

        [TestMethod]
        public void RemoveChecks_ReturnsAllChecks()
        {
            var check = A.Fake<Check>();
            cashDrawer.AddCheck(check);
            var count = cashDrawer.Checks;
            var checks = cashDrawer.RemoveChecks();
            checks.Count().ShouldBe(count);
            cashDrawer.Checks.ShouldBe(0);
        }

        [TestMethod]
        public void RemoveDollarBills_ReturnsAllDollarBills()
        {
            var bills = cashDrawer.RemoveDollarBills();
            cashDrawer.Ones.ShouldBe(0);
            cashDrawer.Fives.ShouldBe(0);
            cashDrawer.Tens.ShouldBe(0);
            cashDrawer.Twenties.ShouldBe(0);
            cashDrawer.Fifties.ShouldBe(0);
            cashDrawer.Hundreds.ShouldBe(0);
        }

        [TestMethod]
        public void RemoveDollarBill_ReturnsRequestedDollarBill()
        {
            var bill = DollarBill.Ten;
            cashDrawer.AddDollarBills(new List<DollarBill> { bill });
            var result = cashDrawer.RemoveDollarBill(DollarBill.Ten);
            result.ShouldBe(bill);
        }
    }
}
