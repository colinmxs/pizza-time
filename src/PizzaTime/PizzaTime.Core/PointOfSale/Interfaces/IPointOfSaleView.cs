namespace PizzaTime.Core.PointOfSale.Interfaces
{
    public interface IPointOfSaleView
    {
        PointOfSaleMachine.Screen Screen { get; }
        bool Active { get; set; }
    }
}