namespace PizzaTime.Core.Food
{
    using PizzaTime.Core.Food.Core;

    public static class PizzaSizes
    {
        public static readonly PizzaSize Small = new PizzaSize
        {
            CostMultiplier = 5.0M,
            Name = "Small"
        };

        public static readonly PizzaSize Medium = new PizzaSize
        {
            CostMultiplier = 7.50M,
            Name = "Medium"
        };

        public static readonly PizzaSize Large = new PizzaSize
        {
            CostMultiplier = 10.0M,
            Name = "Large"
        };

        public static readonly PizzaSize ExtraLarge = new PizzaSize
        {
            CostMultiplier = 15.0M,
            Name = "Extra Large"
        };
    }
}
