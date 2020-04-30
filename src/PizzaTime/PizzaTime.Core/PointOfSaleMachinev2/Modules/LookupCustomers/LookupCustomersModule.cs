using PizzaTime.Core.Customers;
using PizzaTime.Core.PointOfSaleMachinev2.Triggers;
using System.Collections.Generic;
using System.Linq;

namespace PizzaTime.Core.PointOfSaleMachinev2.Modules.LookupCustomers
{
    public class LookupCustomersModule : PointOfSaleModule
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly Dictionary<string, string> _notes;

        public LookupCustomersModule(LookupCustomerModuleConfig config, PointOfSaleMachine pos, IView view) : base(pos, view)
        {
            _customerRepository = pos.Customers;
            _notes = pos.Notes;

            var screenConfig = pos.ViewRouter.Configure(view.Screen);
            TriggersRepo.CancelToMenu.ApplyTo(screenConfig);
            TriggersRepo.EditCustomer.ApplyTo(screenConfig);
            TriggersRepo.AddOrderTo.ApplyTo(screenConfig);
        }        

        public void Edit(Customer customer)
        {
            ViewRouter.Fire(TriggersRepo.EditCustomer.ParameterizedTrigger, customer);
        }

        public void AddOrder(Customer customer)
        {
            ViewRouter.Fire(TriggersRepo.AddOrderTo.ParameterizedTrigger, customer);
        }

        public LookupCustomerResponse Handle(LookupCustomerRequest request)
        {
            IEnumerable<Customer> customers = new List<Customer>();
            switch (request.LookupProperty)
            {
                case LookupProperty.Name:
                    customers = _customerRepository.Search(c => c.FirstName.ToUpperInvariant().Contains(request.SearchValue.ToUpperInvariant()) || c.LastName.ToUpperInvariant().Contains(request.SearchValue.ToUpperInvariant()));
                    break;
                case LookupProperty.Phone:
                    customers = _customerRepository.Search(c => c.PhoneNumber.Contains(request.SearchValue));
                    break;
                case LookupProperty.Address:
                    customers = _customerRepository.Search(c => c.Address.ToUpperInvariant().Contains(request.SearchValue.ToUpperInvariant()));
                    break;
                case LookupProperty.City:
                    customers = _customerRepository.Search(c => c.ZipCode.ToUpperInvariant().Contains(request.SearchValue.ToUpperInvariant()));
                    break;
                case LookupProperty.Remarks:
                    var tempCustomers = new List<Customer>();
                    foreach (var note in _notes)
                    {
                        if (note.Value.ToUpperInvariant().Contains(request.SearchValue.ToUpperInvariant()))
                        {
                            var key = note.Key;
                            tempCustomers.AddRange(_customerRepository.Search(c => c.Id.ToString() == key));
                        }
                    }
                    customers = tempCustomers;
                    break;
                default:
                    customers = new List<Customer>(0);
                    break;
            }

            return new LookupCustomerResponse(true)
            {
                Customers = AttachNotes(customers)
            };
        }

        private IEnumerable<(Customer, string)> AttachNotes(IEnumerable<Customer> customers)
        {
            return customers.Select(c =>
            {
                var valueExists = _notes.TryGetValue(c.Id.ToString(), out string note);
                return (c, valueExists ? note : "");
            });
        }
    }
}
