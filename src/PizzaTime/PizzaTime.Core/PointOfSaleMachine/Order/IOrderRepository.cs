namespace PizzaTime.Core.PointOfSaleMachine.Order
{
    public interface IOrderRepository
    {
        bool Add(Order order);
    }
}