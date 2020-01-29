namespace PizzaTime.Core.PointOfSale.Interfaces
{
    public interface IPointOfSaleView
    {
        Screen Screen { get; }
        bool Active { get; set; }
    }
}