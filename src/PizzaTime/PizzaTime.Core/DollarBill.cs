﻿namespace PizzaTime.Core
{
    public class DollarBill
    {
        public static DollarBill Ten
        {
            get
            {
                return new DollarBill(10M);
            }
        }
        public static DollarBill Twenty
        {
            get
            {
                return new DollarBill(20M);
            }
        }

        public static DollarBill One
        {
            get
            {
                return new DollarBill(1M);
            }
        }
        public static DollarBill Five
        {
            get
            {
                return new DollarBill(5M);
            }
        }

        public static DollarBill Fifty
        {
            get
            {
                return new DollarBill(50M);
            }
        }

        public static DollarBill Hundred
        {
            get
            {
                return new DollarBill(100M);
            }
        }
        private DollarBill() { }
        private DollarBill(decimal amount)
        {
            Amount = amount;
        }

        public decimal Amount { get; private set; }
    }
}