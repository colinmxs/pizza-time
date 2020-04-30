using PizzaTime.Core.Customers;
using PizzaTime.Core.PointOfSaleMachinev2.Modules;
using Stateless;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTime.Core.PointOfSaleMachinev2
{
    public class PointOfSaleMachine
    {
        private Screen CurrentScreen = Screen.SignIn;
        
        internal Dictionary<Screen, PointOfSaleModule> Modules { get; } = new Dictionary<Screen, PointOfSaleModule>();
        internal StateMachine<Screen, Trigger> ViewRouter { get; private set; }
        internal ICustomerRepository Customers { get; }
        internal Dictionary<string, string> Notes { get; }

        public PointOfSaleMachine(ICustomerRepository customers, Dictionary<string, string> notes)
        {
            Notes = notes;
            Customers = customers;

            ViewRouter = new StateMachine<Screen, Trigger>(() => CurrentScreen, s => CurrentScreen = s);           

            ViewRouter.OnTransitioned(t =>
            {
                Modules.SingleOrDefault(m => m.Key == t.Source).Value.View.Deactivate();
                Modules.SingleOrDefault(m => m.Key == t.Destination).Value.View.Activate();
            });
        }        
    }
}
