using PizzaTime.Core.Customers;

namespace PizzaTime.Core.PointOfSaleMachinev2.Triggers
{
    internal static class TriggersRepo
    {
        public static ScreenTrigger SignInToMenu = new ScreenTrigger(Trigger.SignedIn, Screen.Menu);
        public static ScreenTrigger AddCustomer = new ScreenTrigger(Trigger.CustomerAdded, Screen.Menu);
        public static ScreenTrigger CancelToMenu = new ScreenTrigger(Trigger.Cancelled, Screen.Menu);

        public static ScreenTriggerWithParameters<Screen> NavigateTo = new ScreenTriggerWithParameters<Screen>(Trigger.PageRequested, screen => screen);
        public static ScreenTriggerWithParameters<Customer> AddOrderTo = new ScreenTriggerWithParameters<Customer>(Trigger.CustomerAdded, customer => Screen.Orders);
        public static ScreenTriggerWithParameters<Customer> EditCustomer = new ScreenTriggerWithParameters<Customer>(Trigger.EditCustomerRequested, customer => Screen.AddCustomer);
    }
}
