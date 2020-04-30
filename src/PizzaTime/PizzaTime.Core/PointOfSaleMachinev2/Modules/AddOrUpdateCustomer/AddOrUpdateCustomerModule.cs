using PizzaTime.Core.Customers;
using PizzaTime.Core.PointOfSaleMachinev2.Triggers;
using System.Collections.Generic;

namespace PizzaTime.Core.PointOfSaleMachinev2.Modules.AddOrUpdateCustomer
{
    public class AddOrUpdateCustomerModule : PointOfSaleModule
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly Dictionary<string, string> _notes;


        public AddOrUpdateCustomerModule(AddOrUpdateCustomerModuleConfiguration config, PointOfSaleMachine pos, IView view) : base(pos, view)
        {
            _customerRepository = config.CustomerRepo;
            _notes = config.Notes;

            var screenConfig = pos.ViewRouter.Configure(view.Screen);
            
            TriggersRepo.AddCustomer.ApplyTo(screenConfig);
            TriggersRepo.AddOrderTo.ApplyTo(screenConfig);
            TriggersRepo.CancelToMenu.ApplyTo(screenConfig);
        }

        public void Cancel()
        {
            ViewRouter.Fire(Trigger.Cancelled);
        }

        public AddOrUpdateCustomerResponse Handle(AddOrUpdateCustomerRequest request)
        {
            bool success = false;

            if (!string.IsNullOrEmpty(request.Customer.PhoneNumber)
                && !string.IsNullOrEmpty(request.Customer.FirstName)
                && !string.IsNullOrEmpty(request.Customer.LastName))
            {
                var customer = _customerRepository.GetById(request.Customer.Id);
                if (customer != null)
                {
                    _customerRepository.Remove(customer);
                }

                _customerRepository.Add(request.Customer);
                _notes[request.Customer.Id.ToString()] = request.Remarks;

                success = true;
            }

            if (success) 
            {
                if (request.AddOrder) ViewRouter.Fire(TriggersRepo.AddOrderTo.ParameterizedTrigger, request.Customer);
                else ViewRouter.Fire(Trigger.CustomerAdded);
            }


            return new AddOrUpdateCustomerResponse(success)
            {
                Customer = request.Customer
            };
        }
    }
}
