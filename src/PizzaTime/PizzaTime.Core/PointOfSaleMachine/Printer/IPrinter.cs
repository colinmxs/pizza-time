namespace PizzaTime.Core.PointOfSaleMachine.Printer
{
    using PizzaTime.Core.PointOfSaleMachine.Order;

    public interface IPrinter
    {
        Ticket[] PrintTickets(Order order);
    }
}
