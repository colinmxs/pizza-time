using System.Collections.Generic;

namespace PizzaTime.Core.Orders
{
    public interface IOrderItem
    {
        decimal Price { get; }
        string Name { get; }
        string Description { get; }
        IEnumerable<string> SpecialInstructions { get; }
    }
}