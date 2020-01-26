namespace PizzaTime.Core.PointOfSale
{
    using System;

    public class DollarBill
    {
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

        private Guid _id = Guid.NewGuid();

        public decimal Amount { get; private set; }

        public override bool Equals(object obj)
        {
            if (!(obj is DollarBill))
                return false;

            DollarBill bill = (DollarBill)obj;
            // compare elements here
            return bill._id == _id;
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }

        public static bool operator ==(DollarBill left, DollarBill right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DollarBill left, DollarBill right)
        {
            return !(left == right);
        }
    }
}