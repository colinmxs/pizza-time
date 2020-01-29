using PizzaTime.Core.Orders;
using PizzaTime.Core.Tickets;

namespace PizzaTime.Core.Printers
{
    public interface IPrinter
    {
        Ticket[] PrintTickets(Order order);
    }
}
