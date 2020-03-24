using PizzaTime.Core.Conversations;
using PizzaTime.Core.Customers;
using PizzaTime.Core.Orders;
using System;
using System.Collections.Generic;

namespace PizzaTime.Core.Levels
{
    public class Level
    {
        public List<LevelOrder> Orders { get; set; }
    }

    public class LevelOrder
    {
        private Customer _customer;
        private Order _order;
        private IConversationParticipant _convoParticipant;

        public Guid Id = Guid.NewGuid();
        public string FirstName => _customer.FirstName;
        public string LastName => _customer.LastName;
        public string FullName => $"{FirstName} {LastName}";
        public string Address => $"{_customer.Address}";


        public LevelOrder(Order order, Customer customer, IConversationParticipant conversationParticipant)
        {

            _order = order;
            _customer = customer;
            _convoParticipant = conversationParticipant;
        }
    }
}
