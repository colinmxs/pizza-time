namespace PizzaTime.Core.PointOfSaleMachine.OrderRepository
{
    public interface IOrderRepository
    {
        bool Add(Order order);
    }
}