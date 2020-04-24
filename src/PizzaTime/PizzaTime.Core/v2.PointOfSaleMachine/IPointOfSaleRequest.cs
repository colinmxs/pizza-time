namespace PizzaTime.Core.v2.PointOfSaleMachine
{
    public interface IPointOfSaleRequest { }
    public interface IPointOfSaleRequest<T> { }

    public interface IPointOfSaleRequestHandler<T> where T : IPointOfSaleRequest
    {
        void Handle(T request);
    }

    public interface IPointOfSaleRequestHandler<T, T1> where T : IPointOfSaleRequest<T1>
    {
        T1 Handle(T request);
    }
}