namespace PizzaTime.Core.v2.PointOfSaleMachine
{
    public interface IPointOfSaleMachine
    {
        IPointOfSaleModule CurrentModule { get; }        
    }
}
