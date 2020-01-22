namespace PizzaTime.Core.PointOfSaleMachine.Printer
{
    public interface IPrinter
    {
        ITicket PrintTicket(Order order);
    }
}
