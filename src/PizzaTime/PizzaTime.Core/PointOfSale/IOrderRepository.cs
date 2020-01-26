namespace PizzaTime.Core.PointOfSale
{
    public interface IOrderRepository
    {
        bool Add(Order order);
    }
}