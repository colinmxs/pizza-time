namespace PizzaTime.Core.Tests.PointOfSale
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PizzaTime.Core.PointOfSale;
    using Shouldly;

    [TestClass]
    public class CustomerRepositoryTests
    {
        ICustomerRepository customerRepo;

        [TestInitialize]
        public void Initialize()
        {
            customerRepo = new CustomerRepository();
        }

        [TestMethod]
        public void HappyPath()
        {
            var customer = new Customer("Colin", "Smith", "1234567890");
            customerRepo.Add(customer);

            var getByPhoneResult = customerRepo.GetByPhoneNumber("1234567890");
            getByPhoneResult.ShouldNotBeNull();
            getByPhoneResult.Id.ShouldBe(customer.Id);

            var getByIdResult = customerRepo.GetById(customer.Id);
            getByIdResult.ShouldNotBeNull();
            getByIdResult.Id.ShouldBe(customer.Id);

            customerRepo.Remove(customer);
            var shouldBeNull = customerRepo.GetById(customer.Id);
            shouldBeNull.ShouldBeNull();
        }
    }
}
