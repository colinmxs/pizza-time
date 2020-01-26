namespace PizzaTime.Core.Tests.PointOfSale
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.PointOfSale;
    using Shouldly;
    using System;

    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void Constructor_SetsProps()
        {
            var firstName = "Peter";
            var lastName = "Griffin";
            var phoneNumber = "1234567890";
            var customer = new Customer(firstName, lastName, phoneNumber);
            customer.FirstName.ShouldBe(firstName);
            customer.LastName.ShouldBe(lastName);
            customer.PhoneNumber.ShouldBe(phoneNumber);
        }
    }
}
