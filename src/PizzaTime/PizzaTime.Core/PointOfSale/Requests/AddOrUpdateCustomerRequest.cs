﻿using PizzaTime.Core.Customers;

namespace PizzaTime.Core.PointOfSale.Requests
{
    public class AddOrUpdateCustomerRequest
    {
        public Customer Customer { get; set; }
    }
}