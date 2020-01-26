namespace PizzaTime.Core.PointOfSale
{
    public interface IPrinter
    {
        Ticket[] PrintTickets(Order order);
    }
}
