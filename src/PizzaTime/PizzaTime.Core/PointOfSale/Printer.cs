namespace PizzaTime.Core.PointOfSale
{
    public class Printer : IPrinter
    {
        public Ticket[] PrintTickets(Order order)
        {
            var ticket = new Ticket
            {
                OrderItems = order.OrderItems
            };

            return new Ticket[1] { ticket };
        }
    }
}
