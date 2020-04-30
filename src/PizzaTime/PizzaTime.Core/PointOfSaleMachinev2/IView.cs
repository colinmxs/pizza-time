namespace PizzaTime.Core.PointOfSaleMachinev2
{
    public interface IView
    {
        Screen Screen { get; }
        void Activate();
        void Deactivate();
    }
}
