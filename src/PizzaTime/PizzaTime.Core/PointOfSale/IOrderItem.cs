using System.Collections.Generic;

namespace PizzaTime.Core.PointOfSale
{
    public interface IOrderItem
    {
        decimal Price { get; }
        string Name { get; }
        IEnumerable<string> SpecialInstructions { get; }
    }
}