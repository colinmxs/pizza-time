﻿namespace PizzaTime.Core.PaymentOptions
{
    using System;

    public class Check
    {
        public Check(string name, DateTime dateTime, decimal amount)
        {
            Name = name;
            Date = dateTime;
            Amount = amount;
        }

        public string Name { get; }
        public DateTime Date { get; }
        public decimal Amount { get; }
    }
}