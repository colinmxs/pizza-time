﻿using PizzaTime.Core.Orders;

namespace PizzaTime.Core.PointOfSale.Requests
{
    public class PlaceOrderRequest
    {
        public Order Order { get; set; }
    }
}