namespace PizzaTime.Core.PointOfSale
{
    using System;

    public class Customer
    {
        internal Customer() { }

        public Customer(string firstName, string lastName, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Id = Guid.NewGuid();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public Guid Id { get; internal set; }
    }
}
